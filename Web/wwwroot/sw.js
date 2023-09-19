addEventListener('install', event => {
    const preCache = async () => {
        const cache = await caches.open('static-v1');
        return cache.addAll([
            //'/'
            //'/about/',
            //'/static/styles.css'
        ]);
    };
    event.waitUntil(preCache());
});

self.addEventListener('fetch', (event) => {

    //ca c est fait pour avoir une methode fetch qui permet l affichagfe du btn install app
    //mais qui en meme temps ne fuck pas l affichage de progress upload 
    //const catFetch = fetch('sw.js');
    //event.fetchObserver.complete.catch(err => {
    //    if (err.name == 'AbortError') catFetch.abort();
    //});

    //event.respondWith(catFetch);
});