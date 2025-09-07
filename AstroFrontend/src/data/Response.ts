export function ErrorResponse(message: string, status: number) 
{
    return new Response(JSON.stringify({ error: message }), {
        status,
        headers: { 'Content-Type': 'application/json' }
    });
}

export function SuccessResponse(data: any) 
{
    return new Response(JSON.stringify(data), {
        status: 200,
        headers: { 'Content-Type': 'application/json' }
    });
}