<img src="./img/logo.png" width="320">

# Eternal-Antirootkit
EternalAntirootkit is a Windows anti-rootkit that improves detecting kernel based rootkit process hiding its existance by novel PIDB(Process ID Bruteforce). The details of the algorithm is in our paper, ["Study on Detection Method and Development of the Kernel Mode Rootkit"](https://www.koreascience.or.kr/article/CFKO201629368414238.pdf) and ["Dual-Mode Kernel Rootkit Scan and Recovery with Process ID Brute-Force"](https://github.com/eternalklaus/EternalAntirootkit/blob/master/docs/Dual-mode%20Kernel%20Rootkit%20Scan%20and%20Recovery.pdf). This is a stable version of EternalAntirootkit and it currently runs on Windows 10.

<br>

# Installation
`onePunch_antiRootkit.exe`: Click the right mouse button and select "Run as administrator".

EternalAntirootkit currently works on only Windows and we tested on Windows 10. As a standalone software you do not need to install it. This program consists of 2 component, Windows system driver ([.sys](https://github.com/eternalklaus/EternalAntirootkit/blob/master/src/Device-driver/Eternal-Antirootkit.c)), and Driver loader ([.exe](https://github.com/eternalklaus/EternalAntirootkit/blob/master/src/GUI/DKOM_Loader.cpp)). `onePunch_antiRootkit.exe` loads system driver and scan rootkit. 

<br>

# Demo Video
Senario based demo video. 
- Victim :  Infected by rootkit malware and be stolen some data, but remove malware by running `EternalAntiRootkit`. [[Demo]](https://www.youtube.com/watch?v=xHgu3nEJKrY)
- Attacker : After implanting rootkit to victim and steals data, detected by our `EternalAntirootkit`. [[Demo]](https://www.youtube.com/watch?v=0rGmw8LGY6E)

