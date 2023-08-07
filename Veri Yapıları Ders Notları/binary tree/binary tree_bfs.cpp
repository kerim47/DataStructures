//binary tree silme islemleri

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
	printf("%d - ", agac->data);
	dolas(agac->sol);
	
	dolas(agac->sag);
}

//buyukten kucuge siralama - RNL
void dolas_bk(node *agac)
{
	if(agac==NULL)
	{
		return;
	}
	printf("%d - ", agac->data);
	dolas_bk(agac->sag);
	
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


//eleman silme
node *sil(node *agac, int x){
	if(agac==NULL)
	{
		return NULL;
	}
	if(agac->data == x)
	{
		if(agac->sol == NULL && agac->sag == NULL)
		{
			return NULL;
		}
		if(agac->sag!=NULL)
		{
			agac->data = min(agac->sag);
			agac->sag = sil(agac->sag, min(agac->sag));
			return agac;
		}
		agac->data = max(agac->sol);
		agac->sol = sil(agac->sol, max(agac->sol));
		return agac;
		
		//sil(agac(min(agac->sag)));
		
	}
	if(agac->data<x)
	{
		agac->sag = sil(agac->sag,x);
		return agac;
	}
	agac->sol = sil(agac->sol,x);
	return agac;
}

// BFS (Geni�lik �ncelikli Arama)
void BFS(node* agac)
{
    if(agac == NULL)
        return;

    // Kuyruk veri yap�s�n� kullanarak d���mleri tutaca��z
    node* kuyruk[100];
    int bas = 0;
    int son = 0;

    kuyruk[son] = agac;
    son++;

    while(bas < son)
    {
        node* temp = kuyruk[bas];
        printf("%d ", temp->data);

        if(temp->sol != NULL)
        {
            kuyruk[son] = temp->sol;
            son++;
        }

        if(temp->sag != NULL)
        {
            kuyruk[son] = temp->sag;
            son++;
        }

        bas++;
    }
}

//BFS algoritmas�n� kullanarak d���mleri geni�lik �ncelikli olarak dola��r. 

int main()
{
	node *agac = NULL;
	agac = ekle(agac,56);
	agac = ekle(agac,200);
	agac = ekle(agac,26);
	agac = ekle(agac,190);
	agac = ekle(agac,213);
	agac = ekle(agac,18);
	agac = ekle(agac,28);
	agac = ekle(agac,12);
	agac = ekle(agac,24);
	agac = ekle(agac,27);
	
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
	
    printf("BFS: ");
    BFS(agac);
    printf("\n");
	
	
	return 1;
}
