//linear yyapidadir
//ilk gelen eleman ilk cikar, son giren son cikar
//fifo  - first in first out
//fifo icin linked list kullanilabilir

//pipe,  disk , swtich, router ve elektronik devrelerde kullanilir

//array ile queue kullanimi-------------
//ilk yere deger ekle
//diger elemanlar sirasi ile ilk bos indexe yerlestir
//5
//5-8
//5-8-6
//cikarma ise
//ilk elemandar sirasi ile cikar
//5-8-6
//8-6
//6


//linked list icin ise queue---------------------------------------
//basini ve sonunu gosterern isaretci kullanilir ve ekleme ile cikarma ile guncellenir
//front bas, rear ise sonu gosterir
//ekleme icin rear, cikarma islemi icin front guncelle
//kuyruk bos iken front ve rear NULL, tek eleman var ise o elemani gosterir
//birden fazla eleman var ise, front en basi, rear ise en sonu gosterir.


#include <stdio.h>
#include <stdlib.h>


//queue
struct node{
	int data;
	struct node *next;
};

//front ve rear
struct node *front = NULL;
struct node *rear = NULL;


//eleman ekleme - enqueue
int enqueue(int data){
	//kuyruk bos ise
	//yeni node olustur ve deger eklemesi yap
	//front ve rear guncelle
	if(front==NULL){
		struct node *neww = (struct node *)malloc(sizeof(struct node));
		neww->data = data;
		neww->next = NULL;
		
		front = rear = neww;
	}
	//kuyruk bos degil ise
	else{
		//eleman olustur
		struct node *neww = (struct node *)malloc(sizeof(struct node));
		neww->data = data;
		neww->next = NULL;
		
		//sonu guncelle
		rear->next = neww;
		rear = neww;
	}
	
	return 1;
}

//display queue - kuyruk yazdirma
//front'un isaret ettigi degeri index'e al ve sirasi ile gez
int display(){
	
	struct node *index = front;
	//kuyruk bosmu?
	if(front==NULL){
		printf("\nKuyruk Bos \n");
		return 1;
	}
	
	printf("\nKuyruk yazildi : \n");
	//bos degil ise, index NULL olana kadar yazdir
	while(index!=NULL)
	{
		printf("%d - ", index->data);
		index = index->next;
	}
	
	
	return 1;
}


//eleman cikarma - dequeue
int dequeue()
{
	//kuyruk bosmu
	if(front == NULL)
	{
		printf("\nKuyruk bos\n");
	}
	//eleman var ise
	//front diger elemani gostersin
	//suanki elemani yedekle temp ile
	struct node *temp = front;
	
	front = front->next;
	//elemani sil
	free(temp);
	
	return 1;
}

//main
int main()
{
	//eleman ekleme
	enqueue(5);
	enqueue(6);
	enqueue(8);
	//yazdirma
	display();
	enqueue(9);
	enqueue(10);
	
	//yazdirma
	display();
	
	//dequeue
	dequeue();
	//yazdirma
	display();
	//dequeue
	dequeue();
	//yazdirma
	display();
	//dequeue
	dequeue();
	//yazdirma
	display();
	//dequeue
	dequeue();
	//yazdirma
	display();
	//dequeue
	dequeue();
	//yazdirma
	display();
	//dequeue
	dequeue();
	//yazdirma
	display();	
	
	
	enqueue(5);
	enqueue(6);
	//yazdirma
	display();
	
	return 1;
}

