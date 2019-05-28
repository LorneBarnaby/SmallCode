import numpy 
import scipy.special

class NN(object):

    def __init__(self, layersN, lr):
        self.layers = []
        self.learningRate = lr
        self.activation = lambda x: scipy.special.expit(x)

        for i in range(0, len(layersN) - 1):
            layer = NNlayer()
            layer.weights = numpy.random.normal(0.0, pow(layersN[i], -0.5), (layersN[i + 1],layersN[i]))
            self.layers.append(layer)
            pass

        output = NNlayer()

        
        self.layers.append(output)
        pass
    
    def train(self, inputsAsList, targetsAsList):
        inputs = numpy.array(inputsAsList, ndmin=2).T
        targets = numpy.array(targetsAsList, ndmin=2).T
        
        inputs = inputs / 10
        targets = targets / 10
        self.layers[0].outputs = inputs

        for i in range(1, len(self.layers)): #loops through first hidden layer to output layer
            self.layers[i].inputs = numpy.dot(self.layers[i - 1].weights, self.layers[i - 1].outputs)
            self.layers[i].outputs = self.activation(self.layers[i].inputs)

        self.layers[-1].error = targets - self.layers[-1].outputs #output layer error

        for i in range(len(self.layers) - 2, -1, -1): #from last hidden layer back to input
            self.layers[i].error = numpy.dot(self.layers[i].weights.T, self.layers[i + 1].error)
               
        for i in range(len(self.layers) - 2, -1, -1):
            layerUp = self.layers[i + 1]
            self.layers[i].weights += self.learningRate * numpy.dot((layerUp.error * layerUp.outputs * (1.0 - layerUp.inputs)), numpy.transpose(self.layers[i].outputs))   
        pass

    #simple feedforward
    def predict(self, inputsAsList):
        inputs = numpy.array(inputsAsList, ndmin=2).T
        inputs = inputs / 10
        self.layers[0].outputs = inputs

        for i in range(1, len(self.layers)):
            self.layers[i].inputs = numpy.dot(self.layers[i - 1].weights, self.layers[i - 1].outputs)
            self.layers[i].outputs = self.activation(self.layers[i].inputs)

        return self.layers[-1].outputs


class NNlayer(object):

    def __init__(self):
        self.inputs = None
        self.weights = None
        self.outputs = None
        self.error = None