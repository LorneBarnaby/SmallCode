from NeuralNetwork_dyn import NN
import random
import numpy

x = NN([2,132, 132,2], 0.3)


d = [
[[1.0,0.0],[0.0,1.0]],
[[0.0,1.0], [0.0,1.0]],
[[1.0,1.0], [1.0,0.0]],
[[0.0,0.0], [1.0,0.0]]]

for i in range(100):
    Data = random.choice(d)
    x.train(Data[0], Data[1])

output = x.predict([1.0,1.0])
print(numpy.argmax(output))
print(output)