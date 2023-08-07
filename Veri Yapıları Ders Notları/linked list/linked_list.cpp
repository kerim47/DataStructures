//bagli liste
//dinamik boyutludur
//her eleman veri ve sonraki elemani gosteren bir pointer'a sahiptir.

//dizilerin boyutlari sahiptir ama linked list boyutu dinamiktir.
//diziler tanimlanirken boyutluari belirtilmelidir. linked list icin yoktur.
//dizi elemanlari bellekte art arda siralidir ama linked list icin olmayabilir

//dizilerde rastgele erisim var ama linked list icin sirali erisim var
//dizilerde eleman silme veya kaydirilma islemi zordur ama linked list icin kolay
//dizile ayni tur verileri saklar ama linked list farkli turleri saklayabilir

//linked list ozellikleri
//liste basini head ve sonunu tail isimli pointerlar gosterir.
//eleman yok ise head ve tail NULL
//listede tek eleman var ise o elemani
//birden fazla eleman var ise birbirine baglidir ve head liste basi ve tail ise liste sonunu gosterir.


#include <stdio.h>
#include <stdlib.h>

//linked list
struct node{
	int data;
	struct node *next;
};

//head ve tail
struct node *head = NULL;
struct node *tail = NULL;

//addnode
int addNode(int data)
{
	//linked list bos ise, yeni bir node olustur
	if(head==NULL)
	{
		struct node *neww = (struct node *)malloc(sizeof(struct node));
		neww->data = data;
		neww->next = NULL;
		
		//listenin basi ve sonu yeni elemani goster
		//head ve tail guncelle
		head = tail= neww;
	}
	//linked list dolu ise
	else{
		//yeni node olustur, veriyi al ve next NULL yap
		struct node *neww = (struct node *)malloc(sizeof(struct node));
		neww->data = data;
		neww->next = NULL;
		
		//tail guncelle
		tail->next = neww;
		tail = neww;
	}
	return 1;
}

//Listenin basina eleman ekleme
//liste bos ise elemani ekle ve head ile tail guncelle
int addNodeHead(int data){
	if(head==NULL){
		struct node *neww = (struct node *)malloc(sizeof(struct node));
		neww->data = data;
		neww->next = NULL;
	}
	//liste dolu ise
	else{
		//node olustur
		struct node *neww = (struct node*)malloc(sizeof(struct node));
		neww->data = data;
		neww->next = head;
		
		//head guncelle
		head = neww;
	}
}

//listeyi yazdirma
//index adinda bir degisken olustur ve head'in gosterdigi ilk degeri gostersin
//sirasi ile diger elemani ve o elemanin isaret ettigi diger elemana giderel goster
//NULL degeri gelirse yazdirma durdur

int print()
{
	printf("\n");
	printf("Linked list yazildi : \n");
	struct node *index = head;
	while(index!=NULL)
	{
		printf("%d - ",index->data);
		//sonraki elemana git, index yeni degeri index->next olmalidir
		index = index->next;
	}
	printf("\n");
}


//eleman silme
//liste bosmu veya dolumu
//head ise head guncelle
//tail ise tail guncelle
//listede ilgili eleman yok ise
//eger listede var ise onceki ve sonraki elemani birbirine bagla
//onceki eleman prev olarak kullanildi
//index ise gezen yapi
int silme(int data){
	struct node *prev = NULL;
	struct node *index = head;
	
	printf("\n");
	printf("%d silinmis liste",data);
	//linked list bos ise
	if(head==NULL)
	{
		printf("\nLinked list bos\n");
		return 1;
	}
	
	//silinecek eleman head ise
	if(head->data == data)
	{
		struct node *t = head;
		//head yeni degeri gostersin, guncelle
		head = head->next;
		//elemani sil
		free(t);
		return 1;
	}
	
	//listede arama yap, prev kullanilacak, index NULl veya silinmek istenen veriye esit degilse
	while(index!=NULL && index->data!=data)
	{
		prev = index; // onceki eleman, aslinda mevcut eleman
		index = index->next; // index yeni eleman oldu
	}
	
	//index NULL ise
	if(index==NULL){
		printf("\nIstenen deger bulunamadi");
	}
	
	//aranan deger bulunmus ise prev next icin index next'e bagla
	prev->next = index->next;
	
	//silinen eleman tail ise, onceki eleman tail olur ve tail guncelle
	if(tail->data == data){
		tail = prev;
	}
	
	//index sil
	free(index);
	
	
	return 1;
}

//uzunluk
int uzunluk()
{
    int count = 0;
    struct node *index = head;

    while(index != NULL)
    {
        count++;
        index = index->next;
    }

    return count;
}

//ekleme sirali
int eklesirali(int data)
{
    struct node* new_node = (struct node*)malloc(sizeof(struct node));
    new_node->data = data;
    new_node->next = NULL;

    if (head == NULL)
    {
        // Liste boþ ise yeni düðümü baþa ekle
        head = new_node;
        tail = new_node;
        return 1;
    }

    if (data < head->data)
    {
        // Yeni veri, listenin baþýndan küçükse yeni düðümü baþa ekle
        new_node->next = head;
        head = new_node;
        return 1;
    }

    if (data > tail->data)
    {
        // Yeni veri, listenin sonundan büyükse yeni düðümü sona ekle
        tail->next = new_node;
        tail = new_node;
        return 1;
    }

    struct node* current = head;
    struct node* previous = NULL;

    while (current != NULL && data > current->data)
    {
        previous = current;
        current = current->next;
    }

    // Yeni düðümü doðru konuma eklemek için baðlantýlarý güncelle
    previous->next = new_node;
    new_node->next = current;

    return 1;
}




int main()
{
	eklesirali(4);
	eklesirali(5);
	eklesirali(12);
	eklesirali(8);
	eklesirali(9);
	print();
	
	//eleman ekleme
	addNode(10);
	addNode(11);
	addNode(12);
	addNode(13);
	
	//listenin basina eleman ekleme
	addNodeHead(9);
	addNodeHead(8);
	
	addNode(14);
	addNode(15);
	addNode(16);
	
	addNodeHead(7);
	addNodeHead(6);
	
	print();
	
	//liste basi silme
	silme(6);
	print();
	
	
	//liste icinden eleman silme
	silme(11);
	print();
	silme(13);
	print();

	
	//hepsini sil
	silme(8);
	print();
	silme(9);
	print();
	silme(10);
	print();
	silme(12);
	print();
	silme(7);
	print();
	silme(14);
	print();
	silme(15);
	print();
	silme(16);
	print();
	
	
	//listede olmayan eleman silme	
	silme(15);
	print();
	
	addNode(16);
	print();
	addNodeHead(7);
	print();
	addNode(17);
	print();
	
    int length = uzunluk();
    printf("\nLinked list uzunlugu: %d\n", length);
	
	return 1;
}
