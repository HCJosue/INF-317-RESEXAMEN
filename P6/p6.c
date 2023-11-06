#include "stdio.h"
#include "mpi.h"
int main(int argc, char *argv[]){
int procesador,nprocesador,i,suma;
int nenvio,vrecepcion;
int a[10000];
for(i=0;i<10000;i++){
a[i]=0;
}
MPI_Init(&argc,&argv);
MPI_Comm_rank(MPI_COMM_WORLD,&procesador);
MPI_Comm_size(MPI_COMM_WORLD,&nprocesador);
int f=10000/(nprocesador);
if(procesador==0){
  for(i=(procesador)*f;i<f*(procesador+1);i++){
	if(i%2==0){
	 int r=(i/2)+1;
	 r=r*r+1;
	 a[i]=r;
	}
	else{
	 a[i]=i+1;
	}
   }
   MPI_Send(&a,f,MPI_INT,procesador+1,0,MPI_COMM_WORLD);
}
else{
 if(procesador==nprocesador-1){
  MPI_Recv(&a,f*procesador,MPI_INT,procesador-1,0,MPI_COMM_WORLD,MPI_STATUS_IGNORE); 
  for(i=(procesador)*f;i<10000;i++){
	if(i%2==0){
	 int r=(i/2)+1;
	 r=r*r+1;
	 a[i]=r;
	}
	else{
	 a[i]=i+1;
	}      
   }
for(i=0;i<10000;i++){
   printf("%d, ",a[i]);
}
  printf(" \n");
 }
 else{
  MPI_Recv(&a,f*(procesador),MPI_INT,procesador-1,0,MPI_COMM_WORLD,MPI_STATUS_IGNORE);
  for(i=(procesador)*f;i<f*(procesador+1);i++){
	if(i%2==0){
	 int r=(i/2)+1;
	 r=r*r+1;
	 a[i]=r;
	}
	else{
	 a[i]=i+1;
	}
   }
  MPI_Send(&a,f*(procesador+1),MPI_INT,procesador+1,0,MPI_COMM_WORLD);
}
}
MPI_Finalize();
}
