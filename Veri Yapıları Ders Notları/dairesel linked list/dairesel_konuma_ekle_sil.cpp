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


//// Listeye yeni bir d���m ekleyen fonksiyon
node *insertAtPosition(node *start, int data, int position) {
    node *newNode, *ptr;
    int i;

    newNode = (node *)malloc(sizeof(node));
    newNode->x = data;

    if (start == NULL) { // Liste bo�sa, yeni d���m� ba�a ekle
        newNode->next = newNode;
        start = newNode;
    } else if (position == 0) { // Ba�a ekleme
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
                printf("Ge�ersiz konum.\n");
                return start;
            }
        }

        newNode->next = ptr->next;
        ptr->next = newNode;
    }

    return start;
}

// Belirtilen konumdaki d���m� listeden silen fonksiyon
node *deleteAtPosition(node *start, int position) {
    node *currentNode, *previousNode;
    int i;

    if (start == NULL) {
        printf("Liste bo�.\n");
        return start;
    }

    currentNode = start;
    if (position == 0) { // Ba�lang�� d���m�n� silme
        while (currentNode->next != start)
            currentNode = currentNode->next;

        currentNode->next = start->next;
        free(start);
        start = currentNode->next;
    } else { // Di�er d���mleri silme
        for (i = 0; i < position; i++) {
            previousNode = currentNode;
            currentNode = currentNode->next;

            if (currentNode == start) {
                printf("Ge�ersiz konum.\n");
                return start;
            }
        }

        previousNode->next = currentNode->next;
        free(currentNode);
    }

    return start;
}


// Listeyi ba�tan sona do�ru yazd�ran fonksiyon
void display(node *start) {
    node *ptr = start;

    if (start == NULL) {
        printf("Liste bo�.\n");
        return;
    }

    printf("Liste: ");
    do {
        printf("%d ", ptr->x);
        ptr = ptr->next;
    } while (ptr != start);

    printf("\n");
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
	
}
