all: sample.exe \
	simplef_raw.exe simplef_simple.exe \
	webbrick.exe

sample.exe : Sample/bot/simplebot_raw.cs \
		Sample/bot/simplebot_psp.cs \
		Sample/bot/simplebot_simple.cs \
		Sample/bot/simplebot_speed.cs \
		Sample/ev3/ev3_colorsensor.cs \
		Sample/ev3/ev3_gyrosensor.cs \
		Sample/ev3/ev3_touchsensor.cs \
		Sample/Menu.cs 
	cp ../lib/BrickPiNet.dll .
	cp ../lib/libbrickpinet.so .
	gmcs /out:sample.exe \
		-sdk:4.5 \
		/r:BrickPiNet.dll \
		Sample/bot/simplebot_raw.cs \
		Sample/bot/simplebot_psp.cs \
		Sample/bot/simplebot_simple.cs \
		Sample/bot/simplebot_speed.cs \
		Sample/ev3/ev3_colorsensor.cs \
		Sample/ev3/ev3_gyrosensor.cs \
		Sample/ev3/ev3_touchsensor.cs \
		Sample/Menu.cs

simplef_raw.exe: SampleF/simplebot_raw.fs
	fsharpc /out:simplef_raw.exe /r:BrickPiNet.dll SampleF/simplebot_raw.fs
simplef_simple.exe: SampleF/simplebot_simple.fs
	fsharpc /out:simplef_simple.exe /r:BrickPiNet.dll SampleF/simplebot_simple.fs

webbrick.exe: WebBrick/Program.cs Sample/bot/simplebot_simple.cs
	gmcs /out:webbrick.exe \
		-sdk:4.5 \
		/r:BrickPiNet.dll \
		WebBrick/Program.cs \
		Sample/bot/simplebot_simple.cs



clean:
	rm *.o *.dll *.so *.exe
