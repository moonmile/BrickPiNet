all: sample.exe \
	sampleF.exe \
	libbrickpinet.so \
	sampleCs.exe \
	sampleF2.exe

sample.exe: libbrickpinet.so BrickPi.dll sample.cs
	gmcs /out:sample.exe -sdk:4.5 /r:BrickPi.dll sample.cs 
sampleCs.exe: libbrickpinet.so BrickPi.dll sampleCs.cs
	gmcs /out:sampleCs.exe -sdk:4.5 /r:BrickPi.dll sampleCs.cs 
sampleF.exe: libbrickpinet.so BrickPi.dll
	fsharpc /out:sampleF.exe /r:BrickPi.dll sampleF.fs 
sampleF2.exe: libbrickpinet.so BrickPi.dll
	fsharpc /out:sampleF.exe /r:BrickPi.dll sampleF2.fs 

libbrickpinet.so: brickpinet.o 
	gcc -fPIC -shared -o libbrickpinet.so brickpinet.c -lrt -lm -L/usr/local/lib -lwiringPi
BrickPi.dll: BrickPi.cs 
	gmcs /target:library /out:BrickPi.dll \
	-sdk:4.5 \
	BindableBase.cs  \
	BrickPi.cs \
	BPi.cs


clean:
	rm *.o *.dll *.so *.exe
