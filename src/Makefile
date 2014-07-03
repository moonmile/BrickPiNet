all: ../lib/libbrickpinet.so ../lib/BrickPiNet.dll

../lib/libbrickpinet.so: libbrickpinet/brickpinet.c 
	gcc -fPIC -shared -o ../lib/libbrickpinet.so libbrickpinet/brickpinet.c -lrt -lm -L/usr/local/lib -lwiringPi

../lib/BrickPiNet.dll: BrickPiNet/BrickPi.cs BrickPiNet/BPi.cs \
	BrickPiNet/BotPiJoystick.cs 
	gmcs /target:library /out:../lib/BrickPiNet.dll \
	-sdk:4.5 \
	BrickPiNet/BindableBase.cs  \
	BrickPiNet/BrickPi.cs \
	BrickPiNet/BPi.cs \
	BrickPiNet/BotPiJoystick.cs 

clean:
	rm *.o *.dll *.so *.exe
