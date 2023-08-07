#include <stdio.h>
#include <string.h>
#include <stdlib.h>

//struct icinde struct kullanma ve deger atama

typedef struct{
	char takimAdi[30];
	int kurulus;
}takim;

typedef struct{
	char adSoyad[30];
	int yas;
	takim takim;//ilk struct yapisi, ikinci degisken ismi
}futbolcu;


int main()
{
	//farkli kullanim
	takim tk;
	strcpy(tk.takimAdi,"Samsunspor");
	tk.kurulus = 1965;	
	
	
	futbolcu ft;
	strcpy(ft.adSoyad,"Burak Calik");
	ft.yas = 30;
	ft.takim = tk;
	
	printf("Bilgiler : %s %d",ft.takim.takimAdi,ft.takim.kurulus);
	
	return 1;
}
