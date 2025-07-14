/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { RoleDto } from "./role-dto";
import { ClaimDto } from "./claim-dto";

export class UserDto {
    id: string = '00000000-0000-0000-0000-000000000000';
    userName: string = "";
    email: string = "";
    roles: RoleDto[] = [];
    claims: ClaimDto[] = [];
}
