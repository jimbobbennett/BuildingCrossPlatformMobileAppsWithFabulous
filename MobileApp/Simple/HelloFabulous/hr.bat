adb -d forward  tcp:9867 tcp:9867
fabulous --watch --webhook:http://localhost:9867/update