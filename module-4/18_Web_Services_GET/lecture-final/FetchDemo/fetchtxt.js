// filename: fetchtxt.js

// Hook up the fetch buttons
document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('fetchText').addEventListener('click', (e) => {
        startTimer();
        // Why do we NOT have to preventDefault here???
        fetchTextFile();
    });
    document.getElementById('fetchTextVerbose').addEventListener('click', (e) => {
        startTimer();
        fetchTextFileVerbose();
    });
    document.getElementById('fetchPark').addEventListener('click', (e) => {
        startTimer();
        fetchParkData();
    });
    document.getElementById('fetchCOVID').addEventListener('click', (e) => {
        startTimer();
        fetchCOVIDData();
    });
});

let npsURL = 'https://developer.nps.gov/api/v1/parks?parkCode=cuva&fields=images&api_key=sarrXt7VtO7SLrLPx4h2DzH7uE5ZdtMyFlub7BXY';
let covidURL = "https://api.covid19api.com/summary";

/*
    Fetch data from a text file and parse the response. (Embedded then's)
*/
let start;

function startTimer() {
    console.clear();
    clearImages();
    document.getElementById('results').innerHTML = '';
    start = new Date();
}

function logIt(msg) {
    console.log((new Date() - start) + "ms: " + msg);
}

function fetchTextFile() {
    logIt('fetchTextFile 1');
    axios.get('demo.txt')           // send an HTTP request to the relative path 'demo.txt'
                                    // Get a Promise for a Response
        .then((response) => {       // get a Response object once this completes
            logIt('fetchTextFile 2');
            document.getElementById('results').innerText = response.data;   // Response body is in data
        });
        logIt('fetchTextFile 3');
}

/*
    VERBOSE version of the text fetch
*/
function fetchTextFileVerbose() {
    logIt('fetchTextFile 1');

    // Call fetch and get back a Promise of a Response
    let responsePromise = axios.get('demo.txt');
    console.table(responsePromise);

    // Tell the Response what code you want to run when the Promise is fulfilled (.then)
    responsePromise.then(
        (resp) => {
            logIt('fetchTextFile 2');
            document.getElementById('results').innerText = resp.data;
        }
    );
    logIt('fetchTextFile 3');
}

function fetchParkData() {
    logIt('fetchParkData 1');

    // TODO: Send an HTTP GET request to the nps parks api (npsURL)

    axios.get(npsURL).then( resp => {
        logIt("Fetch 2");
        const parks = resp.data;
        if (parks.data.length > 0) {
            const park = parks.data[0];
            document.getElementById('results').innerText = park.description;
            addImages(park.images);
        }
    });
    logIt('fetchParkData 3');
}

function clearImages() {
    const container = document.getElementById('imageContainer');
    container.innerHTML = '';
}
function addImages(images) {
    const container = document.getElementById('imageContainer');
    images.forEach(
        (image) => {
            const img = document.createElement('img');
            img.src = image.url;
            container.appendChild(img);
        }
    );
}

function fetchCOVIDData() {
    logIt('fetchCOVIDData 1');
    axios.get(covidURL)             // sends an HTTP request to the COVID api
        .then((response) => {       // get a Response object once this completes
            logIt('fetchCOVIDData 2');
            const coviddata = response.data;     // The api returns an object with a collection of countries 
            coviddata.Countries.sort((a, b) => b.TotalDeaths - a.TotalDeaths);
            let table = '<table border="1">' +
                '<tr><td>Country</td><td>New cases</td><td>Total cases</td><td>New deaths</td><td>Total Deaths</td><td>New Recovered</td><td>Total Recovered</td></tr>'
            coviddata.Countries.forEach(country => {
                let tr = `<tr><td>${country.Country}</td><td>${country.NewConfirmed}</td><td>${country.TotalConfirmed}</td><td>${country.NewDeaths}</td><td>${country.TotalDeaths}</td><td>${country.NewRecovered}</td><td>${country.TotalRecovered}</td></tr>`
                table += tr;
            });
            table += '</table>';
            document.getElementById('results').innerHTML = table;
        })
    logIt('fetchCOVIDData 3');
}
