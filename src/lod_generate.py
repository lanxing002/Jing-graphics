import cv2
import numpy as np
import PIL.Image as Image


def generate(size, color, lod):
    image = np.zeros((size, size, 3), dtype=np.uint8)
    image[:] = color  # 红色 (BGR格式)

    font = cv2.FONT_HERSHEY_TRIPLEX
    font_scale = 1
    font_color = (0, 127, 25)  # 白色
    thickness = 2

    for i in range(0, size, 64):
        for j in range(0, size, 64):
            text = str(lod)
            text_size = cv2.getTextSize(text, font, font_scale, thickness)[0]
            text_x = j + (64 - text_size[0]) // 2
            text_y = i + (64 + text_size[1]) // 2
            cv2.putText(image, text, (text_x, text_y), font, font_scale, font_color, thickness)

    image[:, :, [0, 1, 2]] = image[:, :, [2, 1, 0]]
    return image


if __name__ == '__main__':
    np.random.seed(516)
    np.random.randn()

    for x in range(11):
        size = 1024 // (2 ** x)
        image = generate(size, [int(np.random.rand() * 255) for _ in range(3)], x)

        path = r'C:\Users\lanxi\Documents\lanxing\codes\ErJiu\Jing-graphics\resources\textures\lod{}.png'.format(x)
        im = Image.fromarray(image)
        im.save(path)
