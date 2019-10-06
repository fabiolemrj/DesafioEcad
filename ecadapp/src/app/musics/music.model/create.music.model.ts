export interface ReqCreateMusic{
    code: string;
    name:string;
    genre:number;
}


export interface RespCreateMusic {
    success: boolean;
    message: string;
    data: ReqCreateMusic;
}

