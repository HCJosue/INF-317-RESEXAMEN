import multiprocessing as mp
from multiprocessing import Pool
def serie(a,b):
  w=""
  for i in range(a,b):
    if(i%2==0):
      w=w+str((((i//2)+1)**2+1))+","
    else:
      w=w+str(i+1)+","
  return w
if __name__=="__main__":
  n=10000
  cantidad=n//mp.cpu_count()
  entrada=[(cantidad*i,cantidad*(i+1)) for i in range(mp.cpu_count())]
  pool=Pool()
  re=pool.starmap(serie,entrada);
  print(re[0]+re[1])
