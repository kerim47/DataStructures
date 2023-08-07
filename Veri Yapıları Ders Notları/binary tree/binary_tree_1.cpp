#include <stdio.h>
#include <stdlib.h>

struct n{
	int data;
	n * sol;
	n * sag;
};

typedef n node;

//ekleme - insertion
node *ekle(node *agac, int x)
{
	//agac bos ise node olustur
	if(agac==NULL)
	{
		node *root = (node *)malloc(sizeof(node));
		root->sol = NULL;
		root->sag = NULL;
		root->data = x;
		return root;
	}
	//agac dolu ise
	//agac icin isaretci olsutur ve iter eklenmek istenen degerden kucuk ise
	node *iter = agac;
	if(iter->data < x)
	{
		agac->sag = ekle(agac->sag,x);
		return agac;
	}
	agac->sol = ekle(agac->sol,x);
	return agac;
}

//dolasma- traversal
//infix, prefix, postfix

//infix - kucukten buyuge siralama - LNR
void dolas(node *agac)
{
	if(agac==NULL)
	{
		return;
	}
	dolas(agac->sol);
	printf("%d - ", agac->data);
	dolas(agac->sag);
}

//buyukten kucuge siralama - RNL
void dolas_bk(node *agac)
{
	if(agac==NULL)
	{
		return;
	}
	dolas_bk(agac->sag);
	printf("%d - ", agac->data);
	dolas_bk(agac->sol);
}

//arama - search
int bul(node * agac, int aranan)
{
	if(agac == NULL)
	{
		return -1;
	}
	if(agac->data==aranan)
	{
		return 1;
	}
	if(bul(agac->sag,aranan)==1)
	{
		return 1;
	}
	if(bul(agac->sol,aranan)==1)
	{
		return 1;
	}
	return -1;
}


//min ve max bulma
int max(node *agac)
{
	while(agac->sag!=NULL)
	{
		agac=agac->sag;
	}
	return agac->data;
}

int min(node *agac)
{
	while(agac->sol!=NULL)
	{
		agac=agac->sol;
	}
	return agac->data;
}

int main()
{
	node *agac = NULL;
	agac = ekle(agac,12);
	agac = ekle(agac,200);
	agac = ekle(agac,190);
	agac = ekle(agac,213);
	agac = ekle(agac,56);
	agac = ekle(agac,24);
	agac = ekle(agac,18);
	agac = ekle(agac,27);
	agac = ekle(agac,28);
	
	//kucukten buyuge siralama - LNR
	dolas(agac);
	printf("\n");
	//buyukten kucuge siralama RNL
	dolas_bk(agac);
	printf("\n");
	//arama
	printf("Arama sonucu : %d",bul(agac,100));
	printf("\n");
	printf("Arama sonucu : %d",bul(agac,24));
	printf("\n");
	//min ve max bulma
	printf("max = %d min %d",max(agac),min(agac));
	printf("\n");
	
	
	return 1;
}
