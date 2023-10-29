#include "stdio.h"
#include "omp.h"
#include <string.h>
void une(char c, char *cadena)
{
    char cadenaT[2];
    cadenaT[0] = c;
    cadenaT[1] = '\0';
    strcat(cadena, cadenaT);
}

void main()
{
    int i,indice=0;
    char frase[]="tres tristes tigres trigaban trigo por culpa del bolivar";
    char a[4][15]={{""},{""},{""},{""}};
    char b[4][15]={{""},{""},{""},{""}};
	#pragma omp parallel shared(frase,indice)
	{
		#pragma omp for reduction(+:indice) private(i)
		for(i=0;i<strlen(frase);i++){
            if(!(frase[i]==' ')){
                if(indice%2==0){
                    une(frase[i],a[omp_get_thread_num()]);
                }
                else{
                    une(frase[i],b[omp_get_thread_num()]);
                }
            }
            if(frase[i+1]==' '){
                if(indice%2==0){
                    une(' ',a[omp_get_thread_num()]);
                }
                else{
                    une(' ',b[omp_get_thread_num()]);
                }
                #pragma omp critical
                {
                indice+=1;
                }
            }
            
		}
	}
    printf("%s%s%s%s\n",a[0],a[1],a[2],a[3]);
    printf("%s%s%s%s\n",b[0],b[1],b[2],b[3]);
}
