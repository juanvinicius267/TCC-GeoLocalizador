import RPi.GPIO as GPIO
from mfrc522 import SimpleMFRC522
import time

leitorRfid = SimpleMFRC522()

result = 2
def doLogin():
    print("Aproxime o cartao da leitora rfid...")
    try:
            id, text = leitorRfid.read()
            print("ID do cartao: ", id)
            if id == 291913269973:
                print("Tag RFID valida!")                
                time.sleep(2)
                result = 1
            else:
                print("Tag RFID nao permitida!")
                time.sleep(2)
                result = 0
            
    finally:
            return result