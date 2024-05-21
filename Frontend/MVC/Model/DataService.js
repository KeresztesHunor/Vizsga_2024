export default class DataService
{
    #baseUrl;

    constructor(baseUrl)
    {
        this.#baseUrl = baseUrl;
    }

    get(path, callback, errorCallback = console.error)
    {
        axios
            .get(this.#baseUrl + "/" + path)
            .then(response => callback(response.data))
            .catch(errorCallback)
        ;
    }
}