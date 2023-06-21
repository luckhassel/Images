export interface ImageDTO{
    Base64Image: string
}

export interface ImageViewModel{
    url: string
}

export interface ResultViewModel<T>{
    result: T,
    validationResult: ValidationResult,
    success: boolean,
}

export interface ResultViewModelWithoutResult{
    validationResult: ValidationResult,
    success: boolean
}

export interface ValidationResult{
    code: number,
    message: string
}