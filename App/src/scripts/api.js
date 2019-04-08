import shared from './shared.js';

class Options
{
    constructor(url, action, controller, data, success, error, fetch_options, path_params) {
        this.action = action;
        this.controller = controller;
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
        this.api_url = "http://localhost:44320/api/";
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

        if (shared.data.isLoggedIn) {
            options.fetch_options.headers.set('Authorization', 'Bearer ' + shared.data.jwt_token);
        }

        if(!options.url)
        {
            options.url = this.api_url;
        }

        options.url += (options.controller ? options.controller : this.name);
        
        if(options.action)
        {
            options.url = [options.url, options.action].join('/');
        }

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
        // se for do tipo get, adiciona na url como query string
        // senão, adiciona como json no corpo da requisição
        if(options.data)
        {
            if(request_type == requestTypes.GET)
            {
                options.url += this.createQueryString(options.data);
            }
            else {
                options.fetch_options.headers.set('Content-Type', 'application/json');
                options.fetch_options.body = JSON.stringify(options.data);
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