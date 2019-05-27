from NeuralNetwork import NeuralNetwork
import random
import numpy
import matplotlib.pyplot

dataFileTraining = open("mnist_train.csv", "r")
dataListTraining = dataFileTraining.readlines()
dataFileTraining.close()

dataFileTesting = open("mnist_test.csv", "r")
dataListTesting = dataFileTesting.readlines()
dataFileTesting.close()

input = 784
hidden = 100 
out = 10

lr = 0.007

n = NeuralNetwork(input, hidden, out, lr)

def performance():
    scorecard = []

    for record in dataListTesting:
        values = record.split(",")
        actualLabel = int(values[0])
        inputs = (numpy.asfarray(values[1:]) / 255.0 * 0.99) + 0.01
        ouputs = n.query(inputs)
        label = numpy.argmax(ouputs)

        if label == actualLabel:
            scorecard.append(1)
        else:
            scorecard.append(0)
    scorearray = numpy.asarray(scorecard)
    print("performace: ", scorearray.sum() / scorearray.size)




for epoch in range(1):
    for record in dataListTraining:
        values = record.split(",")
        inputs = (numpy.asfarray(values[1:]) / 255.0 * 0.99) + 0.01
        targets = numpy.zeros(out) + 0.01
        targets[int(values[0])] = 0.99
        n.train(inputs, targets)
    performance()

for visualTest in range(10):
    val = random.choice(dataListTesting).split(",")
    imgArr = numpy.asfarray(val[1:]).reshape(28,28)
    inputs = (numpy.asfarray(val[1:]) / 255.0 * 0.99) + 0.01
    ouputs = n.query(inputs)
    label = numpy.argmax(ouputs)
    print(label)
    matplotlib.pyplot.imshow(imgArr, cmap="Greys", interpolation="None")
    matplotlib.pyplot.show()

