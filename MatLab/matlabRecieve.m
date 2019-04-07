clc
clear all
tcpipServer = tcpip('0.0.0.0',55000,'NetworkRole','Server');
while(1)
data = membrane(1);
fopen(tcpipServer);
rawData = fread(tcpipServer,14,'char');
for i=1:14 rawwData(i)= char(rawData(i));
end
fclose(tcpipServer);
end