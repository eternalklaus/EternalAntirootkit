# Eternal-Antirootkit
### Korean  
Windows 10에서 동작하는 안티루트킷입니다.  
프로그램은 2개의 모듈로 구성되어 있습니다. 
- 시스템 드라이버
- 실행 프로그램

실행 프로그램을 실행하면 우리의 시스템 드라이버가 로드되며 루트킷 검사를 시작합니다. 
시스템의 Active process links를 순회하며 Hidden process를 검사하기 시작합니다.  
이때, 우리의 독자적인 PIDB(process id bruteforce) 기술을 사용하여 커널레벨 루트킷을 탐지합니다.  
  
따라서 우리의 안티루트킷은 DKOM으로 숨겨진 루트킷 뿐 아니라, Advanced-DKOM 으로 숨겨진 루트킷을 효과적으로 탐지합니다.  

시나리오 기반의 시연 영상은 다음과 같습니다.  
- Victim : https://www.youtube.com/watch?v=xHgu3nEJKrY 감염 후 우리의 안티루트킷으로 치료
- Attacker : https://www.youtube.com/watch?v=0rGmw8LGY6E 공격, 데이터 탈취, 치료로인해 세션끊김 


### Eng.
TODO : English description 
