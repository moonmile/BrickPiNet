all: sample.exe \
	simplef_raw.exe simplef_simple.exe 

sample.exe : Sample/bot/simplebot_raw.cs \
		Sample/bot/simplebot_psp.cs \
		Sample/bot/simplebot_simple.cs \
		Sample/bot/simplebot_speed.cs \
		Sample/ev3/ev3_colorsensor.cs \
		Sample/ev3/ev3_gyrosensor.cs \
		Sample/ev3/ev3_touchsensor.cs 
	cp ../lib/BrickPiNet.dll .
	cp ../lib/libbrickpinet.so .
	gmcs /out:sample.exe \
		-sdk:4.5 \
		/r:BrickPiNet.dll
		Sample/bot/simplebot_raw.cs \
		Sample/bot/simplebot_psp.cs \
		Sample/bot/simplebot_simple.cs \
		Sample/bot/simplebot_speed.cs \
		Sample/ev3/ev3_colorsensor.cs \
		Sample/ev3/ev3_gyrosensor.cs \
		Sample/ev3/ev3_touchsensor.cs 

simplef_raw.exe: SampleF/simplebot_raw.fs
	fsharc /out:simplef_raw.exe /r:BrickPiNet.dll SampleF/simplebot_raw.fs
simplef_simple.exe: SampleF/simplebot_simple.fs
	fsharc /out:simplef_raw.exe /r:BrickPiNet.dll SampleF/simplebot_simple.fs

clean:
	rm *.o *.dll *.so *.exe
