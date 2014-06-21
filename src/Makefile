all: sample.exe sampleF.exe libbrickpinet.so 

sample.exe: libbrickpinet.so BrickPi.dll 
	gmcs /out:sample.exe /r:BrickPi.dll sample.cs 
sampleF.exe: libbrickpinet.so BrickPi.dll
	fsharpc /out:sampleF.exe /r:BrickPi.dll sampleF.fs 

libbrickpinet.so: brickpinet.o 
	gcc -fPIC -shared -o libbrickpinet.so brickpinet.c -lrt -lm -L/usr/local/lib -lwiringPi
BrickPi.dll: BrickPi.cs 
	gmcs /target:library /out:BrickPi.dll BrickPi.cs

