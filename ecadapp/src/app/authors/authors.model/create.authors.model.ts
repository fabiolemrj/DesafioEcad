export interface ReqCreateAuthor{
    code: string;
    name: string;
    category: number;
}


export interface RespCreateAuthor {
    success: boolean;
    message: string;
    data: ReqCreateAuthor;
}
