export interface RespGetUpdateAuthor {
    
    data: ReqUpdateAuthor;
}


export interface ReqUpdateAuthor{
    id: string;
    code: string;
    name: string;
    category: number;
}


export interface RespUpdateAuthor {
    success: boolean;
    message: string;
    data: ReqUpdateAuthor;
}
