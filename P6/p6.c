#include "stdio.h"
#include "mpi.h"
int main(int argc, char *argv[]){
int procesador,nprocesador,i,suma;
int nenvio,vrecepcion;
MPI_Init(&argc,&argv);
MPI_Comm_rank(MPI_COMM_WORLD,&procesador);
MPI_Comm_size(MPI_COMM_WORLD,&nprocesador);
int f=10000/(nprocesador-1);
if(procesador==0){
  for(i=1;i<nprocesador;i++){
	nenvio=i;
	MPI_Send(&nenvio,1,MPI_INT,i,0,MPI_COMM_WORLD);
   }
}
else{
  MPI_Recv(&vrecepcion,1,MPI_INT,0,0,MPI_COMM_WORLD,MPI_STATUS_IGNORE);
  for(i=f*(vrecepcion-1);i<f*(vrecepcion);i++){
	if(i%2==0){
	 int r=(i/2)+1;
	 r=r*r+1;
	 printf("%d\n",r);
	}
	else{
	 printf("%d\n",i+1);
	}
  }
}
MPI_Finalize();
}
