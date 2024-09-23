import cv2 ## 웹캠 불러오기
from cvzone.HandTrackingModule import HandDetector
import socket

# Parameters
width, height = 640, 720 ## 변수화해주기
#Webcam
cap = cv2.VideoCapture(0)
cap.set(3,width)
cap.set(4,height)

#Hand Detector
detector = HandDetector(maxHands=1, detectionCon=0.8)

#Communication
sock = socket.socket(socket.AF_INET,socket.SOCK_DGRAM) ##tcp를 쓸경우 DGRAM 대신 SOCK_STREAM 사용!
serverAddressPort = ("127.0.0.1",5052) ##뒤에 포트번호는 뭐든 상관없음

while True:
    #Get the frame from the webcam
    success, img = cap.read()

    # Flip the image to mirror mode (좌우반전)
    img = cv2.flip(img, 1)

    #Hands
    hands, img = detector.findHands(img)

    data = [] ##마지막에 보내게 될 데이터. 밖에다가 선언하면 안됨!계속 업데이트해줘야하니
    # Landmark values - (x,y,z) * 21
    if hands:
        # Get the first hand detected
        hand = hands[0]
        # Get the landmark list
        lmList = hand['lmList'] ##dictionary
        #print(lmList)
        for lm in lmList:
            flipped_x = width - lm[0]
            data.extend([flipped_x, height - lm[1], lm[2]]) ##y값은 유니티와 반대이기 때문
        #print(data)
        sock.sendto(str.encode(str(data)),serverAddressPort)

    cv2.imshow("Image", img)
    cv2.waitKey(1)