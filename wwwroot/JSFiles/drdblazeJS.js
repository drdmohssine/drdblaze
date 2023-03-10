
export function getLinesInDiv(divId) {
    const div = document.getElementById(divId);

    const text = div.textContent.trim();
    const lines = [];
    const rect = div.getBoundingClientRect();
    const words = text.split(' ');

   
  
    let line = '';
    const span = document.createElement('span');

    for (let i = 0; i < words.length; i++) {
        const word = words[i];
       
        span.textContent += word + ' ';

        div.appendChild(span);
        const spanRect = span.getBoundingClientRect();
        div.removeChild(span);

        if (spanRect.width < rect.width ) {
            line += word + ' ';
            
        } else {
            if (line !== '') {
                lines.push(line.trim());
                line = '';
                span = document.createElement('span');
            }
        }

    }

   
    return lines;
}






let fileHandle;

export function blazorDownloadFile(filename, contentType, content) {
    try {
        // Create a new Blob object from the content
        const blob = new Blob([content], { type: contentType });

        // Use the fetch API to download the file
        fetch(URL.createObjectURL(blob))
            .then(response => {
                // Check if the response is successful
                if (response.ok) {
                    // Create a new Blob object from the response
                    return response.blob();
                }
                throw new Error("Failed to download file");
            })
            .then(blob => {
                // Create an object URL from the blob
                const url = URL.createObjectURL(blob);

                // Create a new <a> element and set its href attribute
                const a = document.createElement("a");
                a.href = url;

                // Set the download attribute of the <a> element
                a.download = filename;

                // Append the <a> element to the document and click on it
                document.body.appendChild(a);
                a.click();

                // Release the object URL
                URL.revokeObjectURL(url);
            })
            .catch(error => {
                console.error(error);
            });
    } catch (error) {
        console.error(error);
    }
}


export function BlazorGetSvgContent(id) {
    var element = document.getElementById(id);
    if (element) {
        return element.outerHTML;
    } else {
        return null;
    }
}

export function BlazorDownloadBase64File(filename, dataUrl) {
    const link = document.createElement('a');
    link.download = filename;
    link.href = dataUrl;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

window.interop = {

  

    getNewFileHandle: async function (suggestedFileName) {
        if (!fileHandle) {
            try {
                if (typeof window.chooseFileSystemEntries === 'function') {
                    // For Chrome 85 and earlier...
                    const opts = {
                        type: 'save-file',
                        accepts: [{
                            description: 'sNotes File',
                            extensions: ['snotes'],
                            mimeTypes: ['application/snotes'],
                        }],
                        suggestedName: suggestedFileName,
                    };
                    fileHandle = await window.chooseFileSystemEntries(opts);
                } else {
                    // handle the case where the function is not defined
                    // For Chrome 86 and later...
                    if ('showSaveFilePicker' in window) {
                        const opts = {
                            types: [{
                                description: 'sNotes File',
                                accept: { 'application/snotes': ['.snotes'] },
                            }],
                            suggestedName: suggestedFileName,
                        };
                        fileHandle = await window.showSaveFilePicker(opts);
                    }
                }
            } catch (e) {
                console.error('File picker was cancelled by the user');
            }
        }

    },

    blazorSaveFile: async function (contentType, content) {

        if (fileHandle) {
            // Define the chunk size, e.g. 1 MB
            const chunkSize = 512 * 1024;
            // Calculate the number of chunks
            const numOfChunks = Math.ceil(content.length / chunkSize);

            // Create a FileSystemWritableFileStream to write to.
            const writable = await fileHandle.createWritable();

            // Write each chunk to the stream.
            for (let i = 0; i < numOfChunks; i++) {
                // Get the current chunk
                const start = i * chunkSize;
                const end = (i + 1) * chunkSize;
                const chunk = content.slice(start, end);

                // Create a new Blob object from the chunk
                const blob = new Blob([chunk], { type: contentType });

                // Write the contents of the chunk to the stream.
                await writable.write(blob);
            }

            // Close the file and write the contents to disk.
            await writable.close();
        }

    },


};


//// Get references to the SVG element and the selection rectangle
//const svg = document.querySelector('svg');
//const selectionRect = document.getElementById('selectionRect');

//// Initialize variables to track the starting position of the selection rectangle
//let startX = 0;
//let startY = 0;

//// Initialize a variable to track whether the user is currently selecting SNRects
//let selecting = false;

//// Add an event listener to the SVG element to handle mouse down events
//svg.addEventListener('mousedown', (event) => {
//    // Set the starting position of the selection rectangle
//    startX = event.clientX;
//    startY = event.clientY;

//    // Set the position and size of the selection rectangle to the starting position
//    selectionRect.setAttribute('x', startX);
//    selectionRect.setAttribute('y', startY);
//    selectionRect.setAttribute('width', 0);
//    selectionRect.setAttribute('height', 0);

//    // Show the selection rectangle
//    selectionRect.style.display = 'inline';

//    // Set selecting to true
//    selecting = true;
//});

//// Add an event listener to the SVG element to handle mouse move events
//svg.addEventListener('mousemove', (event) => {
//    // Check if the user is currently selecting SNRects
//    if (selecting) {
//        // Calculate the new position and size of the selection rectangle
//        const currentX = event.clientX;
//        const currentY = event.clientY;
//        const currentWidth = currentX - startX;
//        const currentHeight = currentY - startY;

//        // Update the position and size of the selection rectangle
//        selectionRect.setAttribute('x', startX);
//        selectionRect.setAttribute('y', startY);
//        selectionRect.setAttribute('width', currentWidth);
//        selectionRect.setAttribute('height', currentHeight);

        

//    }
//});

//// Add an event listener to the SVG element to handle mouse up events
//svg.addEventListener('mouseup', (event) => {
//    // Hide the selection rectangle
//    selectionRect.style.display = 'none';

//    // Set selecting to false
//    selecting = false;
//});
