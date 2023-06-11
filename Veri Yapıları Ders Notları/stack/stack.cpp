//stack
//linear yapidadir
//lifo - son giren ilk cikar
//last in first out - linked list ile kullanilabilir ve array ile kullanilabilir
//bellek yonetimi, swap, geri al butonu, web tarayici geri ve ileri

//array ile stack yapimi--------------------
//ilk eleman ilk index'e yerlestir.
//sonraki elemanlar ise ilk index'e yerlesi ve indexler kaydirilir
//cikarma ise en basindan yapilir
//ekleme : 15
//ekleme : 8-15
//ekleme : 6-8-15
//cikarma : 8-15
//cikarma : 15

//linked list ile stack----------------------
//top listenin basini gosterir ve listenin basi son giren elemandir.
//listeye son giren elemani gosteren isaretci kullanilir ve ekleme ile cikarma islemi ile bu isaretci guncellenir : bu isaretci : top
//stack bos iken top = NULL eger eleman var ise tek olan elemani top isaret eder
//birden fazla eleman var ise top degiskeni en bastaki elemani gosterir.

#include <stdio.h>
#include <stdlib.h>



//stack
struct node{
	int data;
	struct node *next;
};

//top icin
struct node *top = NULL;

//eleman ekleme - push
int push(int data)
{
	//bos ise yeni elemann olustur ve top = neww olacak
	if(top==NULL)
	{
		struct node *neww = (struct node *)malloc(sizeof(struct node));
		neww->data = data;
		neww->next = NULL;
		
		top = neww;
	}
	//dolu ise
	else{
		//eleman olsutur ve basa ekle ve top guncelle
		struct node *neww = (struct node *)malloc(sizeof(struct node));
		neww->data = data;
		neww->next = top;
		
		top = neww;
	}
}

//yazdirma - display
int display()
{
	//ilk degerden basla ve sona git, index = top olmalidir ve sirasi ile gez
	//sonda ise NULL gelirse listeyi yazdirmayi durdur.
	printf("\n");
	
	//bos mu dolu mu
	if(top==NULL)
	{
		printf("Stack bostur \n");
		return 1;
	}
	
	//dolu ise
	struct node *index = top;
	while(index!=NULL)
	{
		printf("%d - ", index->data);
		index = index->next;
	}
	printf("\n");
	
	return 1;
}

//eleman cikarma - pop
int pop()
{
	//bos mu dolu mu
	if(top==NULL)
	{
		printf("\nStack bos \n");
		return 1;
	}
	
	//dolu ise
	struct node *temp = top;
	top = top->next;
	free(temp);
	
	return 1;
}


//main
int main()
{
	//ekleme
	push(1);
	push(2);
	push(3);
	push(4);
	
	//yazdir
	display();
	
	//cikarma
	pop();
	display();
	pop();
	display();
	pop();
	display();
	pop();
	display();
	
	push(4);
	display();
	
	
	
	return 1;
}
