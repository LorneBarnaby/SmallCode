import numpy 
import scipy.special

class NeuralNetwork(object):
    def __init__(self, innodes, hiddnodes, outnodes, learningrate):
        """
        Initialize input, hidden and output nodes
        """
        self.inputNodes = innodes
        self.hiddenNodes = hiddnodes
        self.outputNodes = outnodes

        #Set learning rate 
        self.learningRate = learningrate

        self.weightsInputHidden = numpy.random.normal(0.0, pow(self.inputNodes, -0.5), (self.hiddenNodes, self.inputNodes))
        self.weightsHiddenOutput = numpy.random.normal(0.0, pow(self.hiddenNodes, -0.5), (self.outputNodes, self.hiddenNodes))

        self.activation = lambda x: scipy.special.expit(x)

        pass

    def train(self, inputsList, targetsList):
        inputs = numpy.array(inputsList, ndmin=2).T
        targets = numpy.array(targetsList, ndmin=2).T

        hiddenInputs = numpy.dot(self.weightsInputHidden, inputs)
        hiddenOutputs = self.activation(hiddenInputs) 

        outputLayerInputs = numpy.dot(self.weightsHiddenOutput, hiddenOutputs)
        outputLayerOutputs = self.activation(outputLayerInputs)

        outputsErrors = targets - outputLayerOutputs
        hiddenErrors = numpy.dot(self.weightsHiddenOutput.T, outputsErrors)
         
        self.weightsHiddenOutput += self.learningRate * numpy.dot((outputsErrors * outputLayerOutputs * (1.0 - outputLayerInputs)), numpy.transpose(hiddenOutputs))
        
        self.weightsInputHidden += self.learningRate * numpy.dot((hiddenErrors * hiddenOutputs * (1.0 - hiddenInputs)), numpy.transpose(inputs))

        pass 

    def query(self, inputsList):
        inputs = numpy.array(inputsList, ndmin=2).T

        hiddenInputs = numpy.dot(self.weightsInputHidden, inputs)
        hiddenOutputs = self.activation(hiddenInputs)

        outputLayerInputs = numpy.dot(self.weightsHiddenOutput, hiddenOutputs)
        outputLayerOutputs = self.activation(outputLayerInputs)

        return outputLayerOutputs
     
pass 



