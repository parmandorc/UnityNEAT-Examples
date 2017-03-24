This repository holds the experiments done in the field of Machine Learning applied to Physics in games. 

In order to be able to dedicate as much time as possible to the experiments themselves, the existing framework UnityNEAT has been chosen. UnityNEAT is an implementation of the NEAT algorithm for genetic evolution of artificial neural networks. The experiments that have been performed use neural networks to control different physics objects, and the UnityNEAT framework allows for a quick reinforcement learning mechanism for these.

### StickBall2D

The simplest experiment that served as the initial contact point with this discipline has been designed as a 2D ball that is attached to the top of a stick. The experiment consists on a neural network that controls the base of said stick, and its outputs are the force that needs to be applied to the base of the stick in order to keep it straight up, without the ball falling or the stick colliding with the walls of the window (this is just so the experiment is controlled in a confined space, instead of the ball being dragged to infinity).

In order to do this, the inputs of the neural network that have been chosen are:
- The angle of the stick with respect to the vertical position.
- The current linear velocity of the ball. Usually in these experiments, the angular velocity is used instead. However, linear velocity seems to provide reasonable results too.
- The current position of the base of the stick.

The fitness function that has been chosen is an accumulation of the amount of time the ball has been kept in a vertical position. Precisely, the acumulated score is incremented by the cosine of the angle with respect to the vertical position (that is, by 1 when straight up, by 0 if in the horizontal, and by -1 if straight down). The neural network then tries to maximize this score, usually by trying to keep the ball straight up as much as possible, which is the intended result.


UnityNEAT
=========

UnityNEAT is a port of [SharpNEAT] from pure C# 4.0 to Unity 4.x and 5 (using Mono 2.6), and is integrated to work with Unity scenes for evaluation. UnityNEAT is created by Daniel Jallov as part of his [master's thesis] at the [Center for Computer Games Research] at the IT University in Copenhagen.

All the NEAT code is pure SharpNEAT, but is running in a single thread through Coroutines instead of using Parallel.For as in regular SharpNEAT.

License (UnityNEAT)
------

This project is released under the same license as SharpNEAT: http://sharpneat.sourceforge.net/licensing.htm
which is the [MIT License], changed from GNU General Public License, minimum version 3 in a previous version.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

[SharpNEAT]:http://sharpneat.sourceforge.net/
[Center for Computer Games Research]:http://game.itu.dk/index.php/About
[master's thesis]:http://jallov.com/thesis
[MIT License]:http://opensource.org/licenses/MIT
