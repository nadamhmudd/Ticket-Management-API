//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

export module TicketManagement.App.Services {

export class Client {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    /**
     * @return Success
     */
    all(): Promise<CategoryDtoListResponse> {
        let url_ = this.baseUrl + "/api/Categories/all";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processAll(_response);
        });
    }

    protected processAll(response: Response): Promise<CategoryDtoListResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = CategoryDtoListResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<CategoryDtoListResponse>(null as any);
    }

    /**
     * @param includeHistory (optional) 
     * @return Success
     */
    allwithevents(includeHistory: boolean | undefined): Promise<CategoryEventsDtoListResponse> {
        let url_ = this.baseUrl + "/api/Categories/allwithevents?";
        if (includeHistory === null)
            throw new Error("The parameter 'includeHistory' cannot be null.");
        else if (includeHistory !== undefined)
            url_ += "includeHistory=" + encodeURIComponent("" + includeHistory) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processAllwithevents(_response);
        });
    }

    protected processAllwithevents(response: Response): Promise<CategoryEventsDtoListResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = CategoryEventsDtoListResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<CategoryEventsDtoListResponse>(null as any);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    categories(body: CreateCategoryCommand | undefined): Promise<CategoryDtoResponse> {
        let url_ = this.baseUrl + "/api/Categories";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processCategories(_response);
        });
    }

    protected processCategories(response: Response): Promise<CategoryDtoResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = CategoryDtoResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<CategoryDtoResponse>(null as any);
    }

    /**
     * @return Success
     */
    eventsGET(): Promise<EventDtoListResponse> {
        let url_ = this.baseUrl + "/api/Events";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processEventsGET(_response);
        });
    }

    protected processEventsGET(response: Response): Promise<EventDtoListResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = EventDtoListResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<EventDtoListResponse>(null as any);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    eventsPOST(body: CreateEventCommand | undefined): Promise<EventDtoResponse> {
        let url_ = this.baseUrl + "/api/Events";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processEventsPOST(_response);
        });
    }

    protected processEventsPOST(response: Response): Promise<EventDtoResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = EventDtoResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<EventDtoResponse>(null as any);
    }

    /**
     * @param body (optional) 
     * @return Error
     */
    eventsPUT(body: UpdateEventCommand | undefined): Promise<ProblemDetails> {
        let url_ = this.baseUrl + "/api/Events";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_: RequestInit = {
            body: content_,
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processEventsPUT(_response);
        });
    }

    protected processEventsPUT(response: Response): Promise<ProblemDetails> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 404) {
            return response.text().then((_responseText) => {
            let result404: any = null;
            let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("Not Found", status, _responseText, _headers, result404);
            });
        } else {
            return response.text().then((_responseText) => {
            let resultdefault: any = null;
            let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            resultdefault = ProblemDetails.fromJS(resultDatadefault);
            return resultdefault;
            });
        }
    }

    /**
     * @return Error
     */
    eventsGET2(id: string): Promise<ProblemDetails> {
        let url_ = this.baseUrl + "/api/Events/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processEventsGET2(_response);
        });
    }

    protected processEventsGET2(response: Response): Promise<ProblemDetails> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 404) {
            return response.text().then((_responseText) => {
            let result404: any = null;
            let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("Not Found", status, _responseText, _headers, result404);
            });
        } else {
            return response.text().then((_responseText) => {
            let resultdefault: any = null;
            let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            resultdefault = ProblemDetails.fromJS(resultDatadefault);
            return resultdefault;
            });
        }
    }

    /**
     * @return Error
     */
    eventsDELETE(id: string): Promise<ProblemDetails> {
        let url_ = this.baseUrl + "/api/Events/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "DELETE",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processEventsDELETE(_response);
        });
    }

    protected processEventsDELETE(response: Response): Promise<ProblemDetails> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 404) {
            return response.text().then((_responseText) => {
            let result404: any = null;
            let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("Not Found", status, _responseText, _headers, result404);
            });
        } else {
            return response.text().then((_responseText) => {
            let resultdefault: any = null;
            let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            resultdefault = ProblemDetails.fromJS(resultDatadefault);
            return resultdefault;
            });
        }
    }

    /**
     * @return Success
     */
    export(): Promise<void> {
        let url_ = this.baseUrl + "/api/Events/export";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processExport(_response);
        });
    }

    protected processExport(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(null as any);
    }
}

export class CategoryDto implements ICategoryDto {
    id?: string;
    name?: string | undefined;

    constructor(data?: ICategoryDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
        }
    }

    static fromJS(data: any): CategoryDto {
        data = typeof data === 'object' ? data : {};
        let result = new CategoryDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        return data;
    }
}

export interface ICategoryDto {
    id?: string;
    name?: string | undefined;
}

export class CategoryDtoListResponse implements ICategoryDtoListResponse {
    succeeded?: boolean;
    message?: string | undefined;
    validationErrors?: string[] | undefined;
    data?: CategoryDto[] | undefined;

    constructor(data?: ICategoryDtoListResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.succeeded = _data["succeeded"];
            this.message = _data["message"];
            if (Array.isArray(_data["validationErrors"])) {
                this.validationErrors = [] as any;
                for (let item of _data["validationErrors"])
                    this.validationErrors!.push(item);
            }
            if (Array.isArray(_data["data"])) {
                this.data = [] as any;
                for (let item of _data["data"])
                    this.data!.push(CategoryDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): CategoryDtoListResponse {
        data = typeof data === 'object' ? data : {};
        let result = new CategoryDtoListResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["succeeded"] = this.succeeded;
        data["message"] = this.message;
        if (Array.isArray(this.validationErrors)) {
            data["validationErrors"] = [];
            for (let item of this.validationErrors)
                data["validationErrors"].push(item);
        }
        if (Array.isArray(this.data)) {
            data["data"] = [];
            for (let item of this.data)
                data["data"].push(item.toJSON());
        }
        return data;
    }
}

export interface ICategoryDtoListResponse {
    succeeded?: boolean;
    message?: string | undefined;
    validationErrors?: string[] | undefined;
    data?: CategoryDto[] | undefined;
}

export class CategoryDtoResponse implements ICategoryDtoResponse {
    succeeded?: boolean;
    message?: string | undefined;
    validationErrors?: string[] | undefined;
    data?: CategoryDto;

    constructor(data?: ICategoryDtoResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.succeeded = _data["succeeded"];
            this.message = _data["message"];
            if (Array.isArray(_data["validationErrors"])) {
                this.validationErrors = [] as any;
                for (let item of _data["validationErrors"])
                    this.validationErrors!.push(item);
            }
            this.data = _data["data"] ? CategoryDto.fromJS(_data["data"]) : <any>undefined;
        }
    }

    static fromJS(data: any): CategoryDtoResponse {
        data = typeof data === 'object' ? data : {};
        let result = new CategoryDtoResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["succeeded"] = this.succeeded;
        data["message"] = this.message;
        if (Array.isArray(this.validationErrors)) {
            data["validationErrors"] = [];
            for (let item of this.validationErrors)
                data["validationErrors"].push(item);
        }
        data["data"] = this.data ? this.data.toJSON() : <any>undefined;
        return data;
    }
}

export interface ICategoryDtoResponse {
    succeeded?: boolean;
    message?: string | undefined;
    validationErrors?: string[] | undefined;
    data?: CategoryDto;
}

export class CategoryEventsDto implements ICategoryEventsDto {
    id?: string;
    name?: string | undefined;
    events?: EventDto[] | undefined;

    constructor(data?: ICategoryEventsDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            if (Array.isArray(_data["events"])) {
                this.events = [] as any;
                for (let item of _data["events"])
                    this.events!.push(EventDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): CategoryEventsDto {
        data = typeof data === 'object' ? data : {};
        let result = new CategoryEventsDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        if (Array.isArray(this.events)) {
            data["events"] = [];
            for (let item of this.events)
                data["events"].push(item.toJSON());
        }
        return data;
    }
}

export interface ICategoryEventsDto {
    id?: string;
    name?: string | undefined;
    events?: EventDto[] | undefined;
}

export class CategoryEventsDtoListResponse implements ICategoryEventsDtoListResponse {
    succeeded?: boolean;
    message?: string | undefined;
    validationErrors?: string[] | undefined;
    data?: CategoryEventsDto[] | undefined;

    constructor(data?: ICategoryEventsDtoListResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.succeeded = _data["succeeded"];
            this.message = _data["message"];
            if (Array.isArray(_data["validationErrors"])) {
                this.validationErrors = [] as any;
                for (let item of _data["validationErrors"])
                    this.validationErrors!.push(item);
            }
            if (Array.isArray(_data["data"])) {
                this.data = [] as any;
                for (let item of _data["data"])
                    this.data!.push(CategoryEventsDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): CategoryEventsDtoListResponse {
        data = typeof data === 'object' ? data : {};
        let result = new CategoryEventsDtoListResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["succeeded"] = this.succeeded;
        data["message"] = this.message;
        if (Array.isArray(this.validationErrors)) {
            data["validationErrors"] = [];
            for (let item of this.validationErrors)
                data["validationErrors"].push(item);
        }
        if (Array.isArray(this.data)) {
            data["data"] = [];
            for (let item of this.data)
                data["data"].push(item.toJSON());
        }
        return data;
    }
}

export interface ICategoryEventsDtoListResponse {
    succeeded?: boolean;
    message?: string | undefined;
    validationErrors?: string[] | undefined;
    data?: CategoryEventsDto[] | undefined;
}

export class CreateCategoryCommand implements ICreateCategoryCommand {
    name?: string | undefined;

    constructor(data?: ICreateCategoryCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.name = _data["name"];
        }
    }

    static fromJS(data: any): CreateCategoryCommand {
        data = typeof data === 'object' ? data : {};
        let result = new CreateCategoryCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        return data;
    }
}

export interface ICreateCategoryCommand {
    name?: string | undefined;
}

export class CreateEventCommand implements ICreateEventCommand {
    name?: string | undefined;
    price?: number;
    artist?: string | undefined;
    date?: Date;
    description?: string | undefined;
    imageUrl?: string | undefined;
    categoryId?: string;

    constructor(data?: ICreateEventCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.name = _data["name"];
            this.price = _data["price"];
            this.artist = _data["artist"];
            this.date = _data["date"] ? new Date(_data["date"].toString()) : <any>undefined;
            this.description = _data["description"];
            this.imageUrl = _data["imageUrl"];
            this.categoryId = _data["categoryId"];
        }
    }

    static fromJS(data: any): CreateEventCommand {
        data = typeof data === 'object' ? data : {};
        let result = new CreateEventCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["price"] = this.price;
        data["artist"] = this.artist;
        data["date"] = this.date ? this.date.toISOString() : <any>undefined;
        data["description"] = this.description;
        data["imageUrl"] = this.imageUrl;
        data["categoryId"] = this.categoryId;
        return data;
    }
}

export interface ICreateEventCommand {
    name?: string | undefined;
    price?: number;
    artist?: string | undefined;
    date?: Date;
    description?: string | undefined;
    imageUrl?: string | undefined;
    categoryId?: string;
}

export class EventDto implements IEventDto {
    id?: string;
    name?: string | undefined;
    price?: number;
    artist?: string | undefined;
    date?: Date;
    description?: string | undefined;
    imageUrl?: string | undefined;
    categoryId?: string;

    constructor(data?: IEventDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.price = _data["price"];
            this.artist = _data["artist"];
            this.date = _data["date"] ? new Date(_data["date"].toString()) : <any>undefined;
            this.description = _data["description"];
            this.imageUrl = _data["imageUrl"];
            this.categoryId = _data["categoryId"];
        }
    }

    static fromJS(data: any): EventDto {
        data = typeof data === 'object' ? data : {};
        let result = new EventDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["price"] = this.price;
        data["artist"] = this.artist;
        data["date"] = this.date ? this.date.toISOString() : <any>undefined;
        data["description"] = this.description;
        data["imageUrl"] = this.imageUrl;
        data["categoryId"] = this.categoryId;
        return data;
    }
}

export interface IEventDto {
    id?: string;
    name?: string | undefined;
    price?: number;
    artist?: string | undefined;
    date?: Date;
    description?: string | undefined;
    imageUrl?: string | undefined;
    categoryId?: string;
}

export class EventDtoListResponse implements IEventDtoListResponse {
    succeeded?: boolean;
    message?: string | undefined;
    validationErrors?: string[] | undefined;
    data?: EventDto[] | undefined;

    constructor(data?: IEventDtoListResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.succeeded = _data["succeeded"];
            this.message = _data["message"];
            if (Array.isArray(_data["validationErrors"])) {
                this.validationErrors = [] as any;
                for (let item of _data["validationErrors"])
                    this.validationErrors!.push(item);
            }
            if (Array.isArray(_data["data"])) {
                this.data = [] as any;
                for (let item of _data["data"])
                    this.data!.push(EventDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): EventDtoListResponse {
        data = typeof data === 'object' ? data : {};
        let result = new EventDtoListResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["succeeded"] = this.succeeded;
        data["message"] = this.message;
        if (Array.isArray(this.validationErrors)) {
            data["validationErrors"] = [];
            for (let item of this.validationErrors)
                data["validationErrors"].push(item);
        }
        if (Array.isArray(this.data)) {
            data["data"] = [];
            for (let item of this.data)
                data["data"].push(item.toJSON());
        }
        return data;
    }
}

export interface IEventDtoListResponse {
    succeeded?: boolean;
    message?: string | undefined;
    validationErrors?: string[] | undefined;
    data?: EventDto[] | undefined;
}

export class EventDtoResponse implements IEventDtoResponse {
    succeeded?: boolean;
    message?: string | undefined;
    validationErrors?: string[] | undefined;
    data?: EventDto;

    constructor(data?: IEventDtoResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.succeeded = _data["succeeded"];
            this.message = _data["message"];
            if (Array.isArray(_data["validationErrors"])) {
                this.validationErrors = [] as any;
                for (let item of _data["validationErrors"])
                    this.validationErrors!.push(item);
            }
            this.data = _data["data"] ? EventDto.fromJS(_data["data"]) : <any>undefined;
        }
    }

    static fromJS(data: any): EventDtoResponse {
        data = typeof data === 'object' ? data : {};
        let result = new EventDtoResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["succeeded"] = this.succeeded;
        data["message"] = this.message;
        if (Array.isArray(this.validationErrors)) {
            data["validationErrors"] = [];
            for (let item of this.validationErrors)
                data["validationErrors"].push(item);
        }
        data["data"] = this.data ? this.data.toJSON() : <any>undefined;
        return data;
    }
}

export interface IEventDtoResponse {
    succeeded?: boolean;
    message?: string | undefined;
    validationErrors?: string[] | undefined;
    data?: EventDto;
}

export class ProblemDetails implements IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;

    constructor(data?: IProblemDetails) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.type = _data["type"];
            this.title = _data["title"];
            this.status = _data["status"];
            this.detail = _data["detail"];
            this.instance = _data["instance"];
        }
    }

    static fromJS(data: any): ProblemDetails {
        data = typeof data === 'object' ? data : {};
        let result = new ProblemDetails();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["title"] = this.title;
        data["status"] = this.status;
        data["detail"] = this.detail;
        data["instance"] = this.instance;
        return data;
    }
}

export interface IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;
}

export class UpdateEventCommand implements IUpdateEventCommand {
    id?: string;
    name?: string | undefined;
    price?: number;
    artist?: string | undefined;
    date?: Date;
    description?: string | undefined;
    imageUrl?: string | undefined;
    categoryId?: string;

    constructor(data?: IUpdateEventCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.name = _data["name"];
            this.price = _data["price"];
            this.artist = _data["artist"];
            this.date = _data["date"] ? new Date(_data["date"].toString()) : <any>undefined;
            this.description = _data["description"];
            this.imageUrl = _data["imageUrl"];
            this.categoryId = _data["categoryId"];
        }
    }

    static fromJS(data: any): UpdateEventCommand {
        data = typeof data === 'object' ? data : {};
        let result = new UpdateEventCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["price"] = this.price;
        data["artist"] = this.artist;
        data["date"] = this.date ? this.date.toISOString() : <any>undefined;
        data["description"] = this.description;
        data["imageUrl"] = this.imageUrl;
        data["categoryId"] = this.categoryId;
        return data;
    }
}

export interface IUpdateEventCommand {
    id?: string;
    name?: string | undefined;
    price?: number;
    artist?: string | undefined;
    date?: Date;
    description?: string | undefined;
    imageUrl?: string | undefined;
    categoryId?: string;
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}

}