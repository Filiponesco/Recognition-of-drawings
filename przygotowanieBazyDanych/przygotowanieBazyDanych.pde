size(280, 280);
int total = 1000;
String name = "TheEiffelTower";
String path = "C:\\Users\\fifig\\Documents\\GitHub\\Rozpoznawanie_rysunkow\\Pobrane dane\\";
byte [] data = loadBytes(path+"full_numpy_bitmap_"+name+".npy");
byte [] outData = new byte[total * 784];

int ile = (data.length - 80 ) / 784;
println(ile);
int outIndex = 0;
PImage img = createImage(28, 28, RGB);
img.loadPixels();
for (int n = 0; n < total; n++)
{
  int start = 80 + n * 784;
  for (int i = 0; i < 784; i++)
  {
    int index = i + start;
    byte val = data[index];
    img.pixels[i] = val;
    outData[outIndex] = val;
    outIndex++;
  }
  img.updatePixels();
  int x = 28 * (n % 10);
  int y = 28 * (n / 10);
  image(img, x, y);
}
saveBytes(path+name+"s"+total+".bin", outData);
