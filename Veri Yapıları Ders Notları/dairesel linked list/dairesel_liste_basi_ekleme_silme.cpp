//dairesel yonlu bagli liste
//doubly list

#include <stdio.h>
#include <stdlib.h>

struct n{
	int x;
	n *next;
};

typedef n node;

void bastir(node *r)
{
	while(r!=NULL)
	{
		printf("%d - ",r->x);
		r = r->next;
	}
	printf("\n");
}

void ekle(node *r, int x)
{
	while(r->next!=NULL)
	{
		r = r->next;
	}
	r->next = (node *)malloc(sizeof(node));
	r->next->x = x;
	r->next->next = NULL;
}

node *ekleSirali(node *r, int x)
{
	if(r==NULL)
	{
		//liste bos ise
		r = (node *)malloc(sizeof(node));
		r->next = NULL;
		r->x = x;
		return r;
	}
	
	if(r->x > x)
	{
		//ilk elemandan kucuk olma durumu
		//rooot degisiyor
		node *temp = (node *)malloc(sizeof(node));
		temp->x = x;
		temp->next = r;
		return temp;
	}
	
	node *iter = r;
	while(iter->next!=NULL && iter->next->x < x)
	{
		iter = iter->next;
	}
	node *temp = (node *)malloc(sizeof(node));
	temp->next = iter->next;
	iter->next = temp;
	temp->x = x;
	return r;
}

node *sil(node *r, int x)
{
	node *temp;
	node *iter = r;
	if(r->x = x)
	{
		temp= r;
		r=r->next;
		free(temp);
		return r;
	}
	while(iter->next!=NULL && iter->next->x != x)
	{
		iter = iter->next;
	}
	if(iter->next == NULL)
	{
		printf("sayi bulunamadi");
		return r;
	}
	temp = iter->next;
	iter->next = iter->next->next;
	free(temp);
	return r;
}


//// Listeye yeni bir düðüm ekleyen fonksiyon
node *insertAtPosition(node *start, int data, int position) {
    node *newNode, *ptr;
    int i;

    newNode = (node *)malloc(sizeof(node));
    newNode->x = data;

    if (start == NULL) { // Liste boþsa, yeni düðümü baþa ekle
        newNode->next = newNode;
        start = newNode;
    } else if (position == 0) { // Baþa ekleme
        newNode->next = start;
        ptr = start;

        while (ptr->next != start)
            ptr = ptr->next;

        ptr->next = newNode;
        start = newNode;
    } else { // Araya veya sona ekleme
        ptr = start;
        for (i = 0; i < position - 1; i++) {
            ptr = ptr->next;
            if (ptr == start) {
                printf("Geçersiz konum.\n");
                return start;
            }
        }

        newNode->next = ptr->next;
        ptr->next = newNode;
    }

    return start;
}

// Belirtilen konumdaki düðümü listeden silen fonksiyon
node *deleteAtPosition(node *start, int position) {
    node *currentNode, *previousNode;
    int i;

    if (start == NULL) {
        printf("Liste boþ.\n");
        return start;
    }

    currentNode = start;
    if (position == 0) { // Baþlangýç düðümünü silme
        while (currentNode->next != start)
            currentNode = currentNode->next;

        currentNode->next = start->next;
        free(start);
        start = currentNode->next;
    } else { // Diðer düðümleri silme
        for (i = 0; i < position; i++) {
            previousNode = currentNode;
            currentNode = currentNode->next;

            if (currentNode == start) {
                printf("Geçersiz konum.\n");
                return start;
            }
        }

        previousNode->next = currentNode->next;
        free(currentNode);
    }

    return start;
}


// Listeyi baþtan sona doðru yazdýran fonksiyon
void display(node *start) {
    node *ptr = start;

    if (start == NULL) {
        printf("Liste boþ.\n");
        return;
    }

    printf("Liste: ");
    do {
        printf("%d ", ptr->x);
        ptr = ptr->next;
    } while (ptr != start);

    printf("\n");
}


// Listenin baþýna yeni bir düðüm ekleyen fonksiyon
node *insertAtBeginning(node *start, int data) {
    node *newNode, *ptr;

    newNode = (node *)malloc(sizeof(node));
    newNode->x = data;

    if (start == NULL) { // Liste boþsa, yeni düðümü tek düðüm olarak ekler
        newNode->next = newNode;
        start = newNode;
    } else { // Yeni düðümü listenin baþýna ekler
        ptr = start;

        while (ptr->next != start)
            ptr = ptr->next;

        ptr->next = newNode;
        newNode->next = start;
        start = newNode;
    }

    return start;
}

// Listenin baþýndaki düðümü silen fonksiyon
node *deleteAtBeginning(node *start) {
    node *ptr, *temp;

    if (start == NULL) {
        printf("Liste boþ.\n");
        return start;
    }

    if (start->next == start) { // Tek düðüm varsa, listeden çýkar ve serbest býrakýr
        free(start);
        start = NULL;
    } else { // Ýlk düðümü siler ve baðlantýlarý günceller
        ptr = start;
        while (ptr->next != start)
            ptr = ptr->next;

        temp = start;
        start = start->next;
        ptr->next = start;
        free(temp);
    }

    return start;
}

int main()
{
	
    node *start = NULL;

    start = insertAtPosition(start, 10, 0);
    start = insertAtPosition(start, 20, 0);
    start = insertAtPosition(start, 30, 1);
    start = insertAtPosition(start, 40, 3);

    display(start); // Liste: 20 30 10 40

    start = deleteAtPosition(start, 2);

    display(start); // Liste:
    
    printf("\n");
    start = insertAtBeginning(start, 111111);
    start = insertAtBeginning(start, 22222);
    start = insertAtBeginning(start, 333333);
    
    display(start);

    start = deleteAtBeginning(start);

    display(start);
	
}
