import cv2
import numpy as np
from skimage.measure import shannon_entropy

# Load the original and enhanced images
original_image = cv2.imread(".\\Inputs\\108_right.jpeg", cv2.IMREAD_GRAYSCALE)
enhanced_image = cv2.imread(".\\Results\\108_right.jpeg", cv2.IMREAD_GRAYSCALE)

# Ensure both images have the same dimensions
if original_image.shape != enhanced_image.shape:
    raise ValueError("Images must have the same dimensions for comparison.")

# Calculate PSNR
mse = np.mean((original_image - enhanced_image) ** 2)
max_pixel_value = 255  # Assuming 8-bit images
psnr_value = 20 * np.log10(max_pixel_value / np.sqrt(mse))


# Calculate entropy
entropy_original = shannon_entropy(original_image)
entropy_enhanced = shannon_entropy(enhanced_image)

# Calculate SSIM
def calculate_ssim(image1, image2):
    mean1, var1 = cv2.meanStdDev(image1)
    mean2, var2 = cv2.meanStdDev(image2)
    covar = np.cov(image1.flatten(), image2.flatten())[0, 1]
    c1 = (0.01 * 255) ** 2
    c2 = (0.03 * 255) ** 2
    ssim_value = ((2 * mean1 * mean2 + c1) * (2 * covar + c2)) / ((mean1 ** 2 + mean2 ** 2 + c1) * (var1 ** 2 + var2 ** 2 + c2))
    return ssim_value

ssim_value = calculate_ssim(original_image, enhanced_image)

# Calculate EMEE
error_image = enhanced_image - original_image
emee_value = np.sum(error_image ** 2) / np.sum(original_image ** 2)

# Calculate NCC
# Calculate the means of the images
mean_image1 = np.mean(original_image)
mean_image2 = np.mean(enhanced_image)

# Calculate the NCC numerator and denominators
ncc_numerator = np.sum((original_image - mean_image1) * (enhanced_image - mean_image2))
ncc_denominator = np.sqrt(np.sum((original_image - mean_image1)**2) * np.sum((enhanced_image - mean_image2)**2))

# Calculate the NCC score
ncc = ncc_numerator / ncc_denominator

# Print the results
print(f'PSNR: {psnr_value:.3f} dB')
print(f'Entropy - Original: {entropy_original:.3f}, Enhanced: {entropy_enhanced:.3f}, Difference: {entropy_enhanced-entropy_original:.3f}')
print(f'SSIM: {ssim_value}')
print(f'EMEE: {emee_value:.3f}')
print(f'NCC: {ncc:.3f}')