import cv2
import numpy as np
import matplotlib.pyplot as plt
import os

def enhance(original_image,img_name):

    # Apply advanced noise reduction using Wavelet denoising
    denoised_image = cv2.fastNlMeansDenoisingColored(original_image, None, 10, 10, 7, 21)

    # Apply gamma correction for fine-tuning contrast
    gamma = 1.5  # Experiment with gamma value
    gamma_corrected = np.power(denoised_image / 255.0, gamma) * 255.0
    gamma_corrected = gamma_corrected.astype(np.uint8)

    # Convert the gamma-corrected image to LAB color space
    lab_image = cv2.cvtColor(gamma_corrected, cv2.COLOR_BGR2LAB)

    # Split the LAB image into channels
    l_channel, a_channel, b_channel = cv2.split(lab_image)

    # Apply CLAHE to the L channel for enhancing contrast
    clahe = cv2.createCLAHE(clipLimit=4.0, tileGridSize=(8, 8))  # Adjust parameters
    clipped_l_channel = clahe.apply(l_channel)

    # Merge the enhanced L channel with the original A and B channels
    enhanced_lab_image = cv2.merge((clipped_l_channel, a_channel, b_channel))

    # Convert the enhanced LAB image back to BGR color space
    enhanced_image = cv2.cvtColor(enhanced_lab_image, cv2.COLOR_LAB2BGR)

    # Calculate the absolute difference between the original and enhanced images
    diff_image = cv2.absdiff(denoised_image, enhanced_image)

    # Display the original and enhanced images side by side
    fig, axes = plt.subplots(1, 5, figsize=(12, 6))
    axes[0].set_title('Original Image')
    axes[0].imshow(cv2.cvtColor(original_image, cv2.COLOR_BGR2RGB))
    axes[0].axis('off')

    axes[1].set_title('Denoised Image')
    axes[1].imshow(cv2.cvtColor(denoised_image, cv2.COLOR_BGR2RGB))
    axes[1].axis('off')

    axes[2].set_title('Gamma Correction')
    axes[2].imshow(cv2.cvtColor(gamma_corrected, cv2.COLOR_BGR2RGB))
    axes[2].axis('off')

    axes[3].set_title('CLAHE (Final Image)')
    axes[3].imshow(cv2.cvtColor(enhanced_image, cv2.COLOR_BGR2RGB))
    axes[3].axis('off')

    axes[4].set_title('Absolute Difference')
    axes[4].imshow(cv2.cvtColor(diff_image, cv2.COLOR_BGR2RGB))
    axes[4].axis('off')

    # Save Plot Image
    if not os.path.exists('Plots'):
        os.mkdir('Plots')

    plt.tight_layout()
    plt.savefig('Plots/' + img_name + '.jpeg', bbox_inches='tight')
    # plt.show()

    # Save Output
    if not os.path.exists('Results'):
        os.mkdir('Results')

    cv2.imwrite('Results/' + img_name + '.jpeg', enhanced_image)


# Parameters
# img_name = '427_right'
# img_path = 'Inputs/' + img_name + '.jpeg'
# original_image = cv2.imread(img_path)
# enhance(original_image, img_name)


InputFolder = ".\\Inputs"
filesArray = [x for x in os.listdir(InputFolder) if os.path.isfile(os.path.join(InputFolder,x))]

for file_name in filesArray:
    original_image = cv2.imread(InputFolder+"\\"+file_name)
    file_name_no_extension = os.path.splitext(file_name)[0]
    enhance(original_image,file_name_no_extension)