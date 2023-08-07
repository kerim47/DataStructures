#include <stdio.h>
#include <string.h>
#include <stdlib.h>

//1
struct kitap{
	char kitapAdi[30];
	float fiyat;
	int sayfa;
};

//2, typedef kullanýrsan int main içinde struct kullanmana gerek yoktur
typedef struct yazar{//eski
	char adSoyad[30];
	int yas;
}yazar;//yeni, bunu yazmasanda olur


int main()
{
	//1 icin direct
	struct kitap kitap1;
	strcpy(kitap1.kitapAdi,"Turklerin Tarihi");
	kitap1.fiyat = 17.50;
	kitap1.sayfa = 350;
	
	printf("Bilgiler : %s %f %d\n",kitap1.kitapAdi,kitap1.fiyat,kitap1.sayfa);
	
	
	//1 icin undirect - pointer ile
	struct kitap *kitap2 = (struct kitap *)malloc(sizeof(struct kitap));
	strcpy(kitap2->kitapAdi,"Fabrika Ayari");
	kitap2->fiyat = 16.50;
	kitap2->sayfa = 3000;
	
	printf("Bilgiler : %s %f %d\n", kitap2->kitapAdi,kitap2->fiyat,kitap2->sayfa);
	
	
	//typedef - direct
	yazar yazar1;
	strcpy(yazar1.adSoyad,"Ýlber Ortayli");
	yazar1.yas = 74;
	
	//typedef - undirect
	yazar *yazar2 = (yazar *)malloc(sizeof(yazar));
	strcpy(yazar2->adSoyad, "Hayati Inanc");
	yazar2->yas = 60;
	
	printf("Yazar 1: %s %d\n", yazar1.adSoyad, yazar1.yas);
	printf("Yazar 2: %s %d\n", yazar2->adSoyad, yazar2->yas);
	
	
	
	return 1;
}
