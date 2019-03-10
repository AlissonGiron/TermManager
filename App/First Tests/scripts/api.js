class Options
{
    constructor(data, success, error, fetch_options) {
        this.data = data;
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

    get = options => this.doRequest(this.createValidOptions("GET", options));
    post = options => this.doRequest(this.createValidOptions("POST", options));
    put = options => this.doRequest(this.createValidOptions("PUT", options));
    delete = options => this.doRequest(this.createValidOptions("DELETE", options));
    filter = options => this.doRequest(this.createValidOptions("filter", options));

    createValidOptions = (request_type, options) => {
        if(!options) options = {};
        if(!options.fetch_options) options.fetch_options = {};
        if(!options.fetch_options.headers) options.fetch_options.headers = new Headers();

        let setOption = (field, trueCallback, falseCallback) => field ? trueCallback(field) : falseCallback(field);

        options.url = setOption(options.url, null, () => this.api_url + this.name);

        if(request_type == "filter") 
        {
            options.url += "/filter";
            request_type = "POST";
        }

        options.fetch_options.method = request_type;
        if(options.data) 
        {
            if(request_type == "POST")
            {
                options.fetch_options.headers.set('Content-Type', 'application/json');
                options.fetch_options.body = JSON.stringify(options.data);
            }
            else {
                options.url += this.createUrlQuery(options.data);
            }
        }

        return options;
    }

    createUrlQuery = data => "?" + Object.entries(data)
                                   .map(p => p.map(encodeURIComponent).join('='))
                                   .join('&');

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