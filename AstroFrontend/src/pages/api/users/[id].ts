import type { APIRoute } from 'astro';

import { GetApiEndpoint } from "@data/AstroDefs.ts";
import { ErrorResponse, SuccessResponse } from "@data/Response.ts";
import { User } from "@data/Types.ts";

export const GET: APIRoute = async ({ params }) => {
    const { id } = params;

    const BACKEND_URL = GetApiEndpoint() + "/users";
    try
    {
        const response = await fetch(`${BACKEND_URL}/${id}`, {
            method: 'GET',
            headers: {'Content-Type': 'application/json'}
        });

        if (!response.ok) 
        {
            if (response.status === 404) 
            { 
                return ErrorResponse('User not found', 404);
            }
            return ErrorResponse(`Backend error: ${response.status}`, response.status);
        }

        const userData = await response.json();
        const user = new User(
            userData.Id,
            userData.UserName,
            userData.Password,
            userData.DisplayName,
            userData.Email
        );

        return SuccessResponse(user);
    }
    catch (error: any)
    {
        console.error('Backend error:', error);
        return ErrorResponse('Internal server error', 500);
    }
}