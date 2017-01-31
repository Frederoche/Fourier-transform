# Fourier-transform

A simple C# implementation of the fourier transform with:
  - The naive 2D DFT implementation
  - The 1D FFT implementation
  - The 2D FFT based on the 1D FFT and its respective inverse
  - The butterworth lowpass filter
  - Phillips spectrum 
  - It works as it is now for squared images

<img src="https://github.com/Frederoche/Fourier-transform/blob/master/2DDFT/Pictures/Inversetransform.jpg" width="128">
<img src="https://github.com/Frederoche/Fourier-transform/blob/master/2DDFT/Pictures/SpectrumForwardTransform.jpg" width="128">
<img src="https://github.com/Frederoche/Fourier-transform/blob/master/2DDFT/Pictures/filteredImageWithButterWorth.jpg" width="128">
<img src="https://github.com/Frederoche/Fourier-transform/blob/master/2DDFT/Pictures/phillipsSpatialDomain.jpg" width="128">
<img src="https://github.com/Frederoche/Fourier-transform/blob/master/2DDFT/Pictures/phillipsSpectrum.jpg" width="128">

<pre><code class='highlight highlight-source-cs"'>
var fft = new FFT2D(256);
var spectrum = fft.Forward(image);

//APPLY ANY KIND OF FILTER

fft.Inverse(spectrum).ToPicture("path to picture");
</code></pre>

MIT License

Copyright (c) 2017 Frederic Dumont

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
