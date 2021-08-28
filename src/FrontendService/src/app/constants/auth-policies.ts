import { AuthPolicy } from '../auth/auth-policy';
import { AuthClaims } from './auth-claims';

export const AuthPolicies = {
    KanOefeningenZienPolicy: {
        requiredClaims: [
            AuthClaims.FitOefeningRead,
            AuthClaims.FitOefeningPrestatieRead,
            AuthClaims.FitOefeningPrestatieAdd
        ]
    },
    KanOefeningenToevoegenPolicy: {
        requiredClaims: [
            AuthClaims.FitOefeningAdd
        ]
    },
    KanOefeningenAanpassenPolicy: {
        requiredClaims: [
            AuthClaims.FitOefeningEdit
        ]
    }
}