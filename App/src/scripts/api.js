class Options
{
    constructor(url, data, success, error, fetch_options, path_params) {
        this.url = url;
        this.data = data;
        this.path_params = path_params; // vetor de valores, ex: [1,3,2] = url/1/3/2
        this.success = success;
        this.error = error;
        this.fetch_options = fetch_options;
    }
}

class Api {
    constructor(name) {
        this.name = name;
        this.api_url = "https://localhost:44320/api/";
    }

    get = options => this.doRequest(this.createValidOptions(requestTypes.GET, options));
    post = options => this.doRequest(this.createValidOptions(requestTypes.POST, options));
    put = options => this.doRequest(this.createValidOptions(requestTypes.PUT, options));
    delete = options => this.doRequest(this.createValidOptions(requestTypes.DELETE, options));
    filter = options => this.doRequest(this.createValidOptions(requestTypes.FILTER, options));

    createValidOptions = (request_type, options) => {

        // inicializa os objetos
        if(!options) options = {};
        if(!options.fetch_options) options.fetch_options = {};
        if(!options.fetch_options.headers) options.fetch_options.headers = new Headers();

        let setOption = (field, trueCallback, falseCallback) => field ? trueCallback(field) : falseCallback(field);

        // se não tiver uma url definida, utiliza uma padrão
        options.url = setOption(options.url, null, () => this.api_url + this.name);

        // se for uma requisição de filtros, define a url e o tipo para POST
        if(request_type == requestTypes.FILTER) 
        {
            options.url += "/filter";
            request_type = requestTypes.POST;
        }

        // define o method da requisição com o passado por parametro
        options.fetch_options.method = request_type;

        // se foi definido algum path param, adiciona na url
        if(options.path_params)
        {
            options.url += this.createPathQuery(options.path_params);
        }

        // se foi definido algum dado para enviar com a requisição
        // se for do tipo post, adiciona como json no corpo da requisição
        // se for do tipo get, adiciona na url como query string
        if(options.data) 
        {
            if(request_type == requestTypes.POST)
            {
                options.fetch_options.headers.set('Content-Type', 'application/json');
                options.fetch_options.body = JSON.stringify(options.data);
            }
            else {
                options.url += this.createQueryString(options.data);
            }
        }

        return options;
    }

    createQueryString = data => "?" + Object.entries(data)
                                   .map(p => p.map(encodeURIComponent).join('='))
                                   .join('&');
    
    createPathQuery = data => "/" + data.join('/');

    formatResponse = data =>
    {
        try {
            return JSON.parse(data);
        }
        catch {
            return data;
        }
    }

    logRequest = data => {
        console.log("==============================================================");
        console.log("REQUEST - " + new Date().toLocaleString());
        console.log(this.formatResponse(data));
        console.log("==============================================================");
    }

    fetchSuccess = (successCallback, response) => successCallback 
                                                ? response.text().then((data) => successCallback(this.formatResponse(data), response))
                                                : response.text().then(this.logRequest);

    fetchError = (errorCallback, err) => errorCallback ? errorCallback(err) : console.log('Fetch Error :-S', err);

    doRequest = options => fetch(options.url, options.fetch_options)
                                .then((data) => this.fetchSuccess(options.success, data))
                                .catch((data) => this.fetchError(options.error, data));
}

var requestTypes = {
    POST: "POST",
    GET: "GET",
    PUT: "PUT",
    DELETE: "DELETE",
    FILTER: "FILTER"
}

class Query {
    constructor(take, skip, track) {
        this.filters = [];
        this.includes = [];
        this.sorts = [];
        this.take = take;
        this.skip = skip;
        this.track = track;
    }

    addFilter = function(field, operator, value) {
        this.filters.push(new Filter(field, operator, value));
    }
}

class Filter {
    constructor(field, operator, value) {
        this.field = field;
        this.operator = operator;
        this.value = value;
    }
}

export {Api};