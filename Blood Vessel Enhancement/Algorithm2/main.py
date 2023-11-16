import cv2
import numpy as np
import matplotlib.pyplot as plt
import os


def gamma_correction(original_image, gamma=1.0):
    # Apply gamma correction to adjust brightness
    inv_gamma = 1.0 / gamma
    table = np.array([((i / 255.0) ** inv_gamma) * 255 for i in np.arange(0, 256)]).astype("uint8")
    corrected_image = cv2.LUT(original_image, table)
    return corrected_image

def enhance_image(original_image, img_name, sigmaX=10):
    # Pre-processing steps
    gamma_image = gamma_correction(original_image, gamma=1.2)  # Apply gamma correction for brightness
    clahe = cv2.createCLAHE(clipLimit=2.0, tileGridSize=(8, 8))
    LAB_image = cv2.cvtColor(gamma_image, cv2.COLOR_RGB2LAB)  # Convert to LAB color space for CLAHE
    l, a, b = cv2.split(LAB_image)
    l = clahe.apply(l)  # Apply CLAHE to the L channel
    clahe_image = cv2.merge((l, a, b))
    clahe_image = cv2.cvtColor(clahe_image, cv2.COLOR_LAB2RGB)  # Convert back to RGB

    # Split the image into color channels
    b, g, r = cv2.split(clahe_image)

    # Apply enhancement to each channel separately
    r = cv2.addWeighted(r, 4, cv2.GaussianBlur(r, (0, 0), sigmaX), -4, 128)
    g = cv2.addWeighted(g, 4, cv2.GaussianBlur(g, (0, 0), sigmaX), -4, 128)
    b = cv2.addWeighted(b, 4, cv2.GaussianBlur(b, (0, 0), sigmaX), -4, 128)

    # Merge the color channels back into an RGB image
    gaussian_image = cv2.merge((b, g, r))

    # Blend the enhanced image with the original image using a weight
    alpha = 0.5  # Adjust this value to control the blending effect
    final_image = cv2.addWeighted(original_image, 1 - alpha, gaussian_image, alpha, 0)

    # Display the original and enhanced images side by side
    fig, axes = plt.subplots(1, 5, figsize=(12, 6))
    axes[0].set_title('Original Image')
    axes[0].imshow(cv2.cvtColor(original_image, cv2.COLOR_BGR2RGB))
    axes[0].axis('off')

    axes[1].set_title('Gamma Correction')
    axes[1].imshow(cv2.cvtColor(gamma_image, cv2.COLOR_BGR2RGB))
    axes[1].axis('off')

    axes[2].set_title('CLAHE')
    axes[2].imshow(cv2.cvtColor(clahe_image, cv2.COLOR_BGR2RGB))
    axes[2].axis('off')

    axes[3].set_title('Gaussian Blur')
    axes[3].imshow(cv2.cvtColor(gaussian_image, cv2.COLOR_BGR2RGB))
    axes[3].axis('off')

    axes[4].set_title('Blending Image')
    axes[4].imshow(cv2.cvtColor(final_image, cv2.COLOR_BGR2RGB))
    axes[4].axis('off')

    if not os.path.exists('Plots'):
        os.mkdir('Plots')

    plt.tight_layout()
    plt.savefig('Plots/' + img_name + '.jpeg', bbox_inches='tight')
    # plt.show()

    if not os.path.exists('Results'):
            os.mkdir('Results')

    cv2.imwrite('Results/' + img_name + '.jpeg', final_image)

def main():

    # # Parameters
    # img_name = '108_left'
    # img_path = 'Inputs/' + img_name + '.jpeg'
    # original_image = cv2.imread(img_path)
    # enhance_image(original_image, img_name, sigmaX=150)
    

    InputFolder = ".\\Inputs"
    filesArray = [x for x in os.listdir(InputFolder) if os.path.isfile(os.path.join(InputFolder,x))]

    for file_name in filesArray:
        original_image = cv2.imread(InputFolder+"\\"+file_name)
        file_name_no_extension = os.path.splitext(file_name)[0]
        enhance_image(original_image,file_name_no_extension, sigmaX=150)


if __name__ == '__main__':
    main()