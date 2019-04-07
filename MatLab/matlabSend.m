clc
clear all
tcpipClient = tcpip('127.0.0.1',55000,'NetworkRole','Client');
set(tcpipClient,'Timeout',30);
fopen(tcpipClient);
a='yah!! we could make it';
fwrite(tcpipClient,a);
fclose(tcpipClient);