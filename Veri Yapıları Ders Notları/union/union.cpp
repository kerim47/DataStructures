//birden fazla deðiskeni tek bir yerden tanimlama imkani saglar
//union icinde ilgili alan olusturur ve en buyuk degiksenin alani kullanilir
//union icindeki degiskenler ortak kullanim alani olusturur.
//birden fazla alan ortak kullanilmaz, kullanmak icin overwrite kullan

#include <stdio.h>
#include <string.h>

//1
union ogrenci
{
	char isim[20];
	int no;
	float ort;
};

//2
typedef union
{
	char isim[20];
	int yas;
}ogretmen;


int main()
{
	printf("Boyut %ld Byte \n",sizeof(union ogrenci));
	
	//1
	union ogrenci o;
	strcpy(o.isim, "Yucel");
	printf("Isim : %s\n",o.isim);
	
	o.no = 148;
	printf("No : %d \n",o.no);
	
	printf("Isim : %s \n",o.isim);
	
	o.ort = 85.5;
	printf("Ortalama : %f\n", o.ort);
	
	
	//typedef ilen kullanim
	ogretmen ogrt;
	strcpy(ogrt.isim,"Ismail\n");
	printf("Ogretmen adi: %s\n",ogrt.isim);
	
	ogrt.yas = 45;
	printf("Ogretmen yas : %d",ogrt.yas);
	
	return 1;
}
