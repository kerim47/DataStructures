#ifndef linked_list_h
#define linked_list_h

// Hafızadan yer acma
#define new_place place()

// Dugum tanımlamaları

struct NODE{

	int value;
	struct NODE* next;
}NODE;
typedef struct NODE Node; 

// Fonksiyon prototipleri
void add(Node*, int);
void print(Node*);
Node* place();
#include "linked_list.c"
#endif
