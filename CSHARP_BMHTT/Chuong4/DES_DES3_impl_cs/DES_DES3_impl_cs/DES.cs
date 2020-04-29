using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
//  VB.NET translation by Ted Ehrich
//  Note: Mode is CBC
//
//  Original license from des.cpp:
//
//  FIPS-46-3 compliant 3DES implementation
//
//  Copyright (C) 2001-2003  Christophe Devine
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//

namespace DES_DES3_impl_cs
{
    class DES
    {
        // the eight DES S-boxes
        private uint[] SB1 = new[] { 0x01010400U, 0x00000000U, 0x00010000U, 0x01010404U, 0x01010004U, 0x00010404U, 0x00000004U, 0x00010000U, 0x00000400U, 0x01010400U, 0x01010404U, 0x00000400U, 0x01000404U, 0x01010004U, 0x01000000U, 0x00000004U, 0x00000404U, 0x01000400U, 0x01000400U, 0x00010400U, 0x00010400U, 0x01010000U, 0x01010000U, 0x01000404U, 0x00010004U, 0x01000004U, 0x01000004U, 0x00010004U, 0x00000000U, 0x00000404U, 0x00010404U, 0x01000000U, 0x00010000U, 0x01010404U, 0x00000004U, 0x01010000U, 0x01010400U, 0x01000000U, 0x01000000U, 0x00000400U, 0x01010004U, 0x00010000U, 0x00010400U, 0x01000004U, 0x00000400U, 0x00000004U, 0x01000404U, 0x00010404U, 0x01010404U, 0x00010004U, 0x01010000U, 0x01000404U, 0x01000004U, 0x00000404U, 0x00010404U, 0x01010400U, 0x00000404U, 0x01000400U, 0x01000400U, 0x00000000U, 0x00010004U, 0x00010400U, 0x00000000U, 0x01010004U };
        private uint[] SB2 = new[] { 0x80108020U, 0x80008000U, 0x00008000U, 0x00108020U, 0x00100000U, 0x00000020U, 0x80100020U, 0x80008020U, 0x80000020U, 0x80108020U, 0x80108000U, 0x80000000U, 0x80008000U, 0x00100000U, 0x00000020U, 0x80100020U, 0x00108000U, 0x00100020U, 0x80008020U, 0x00000000U, 0x80000000U, 0x00008000U, 0x00108020U, 0x80100000U, 0x00100020U, 0x80000020U, 0x00000000U, 0x00108000U, 0x00008020U, 0x80108000U, 0x80100000U, 0x00008020U, 0x00000000U, 0x00108020U, 0x80100020U, 0x00100000U, 0x80008020U, 0x80100000U, 0x80108000U, 0x00008000U, 0x80100000U, 0x80008000U, 0x00000020U, 0x80108020U, 0x00108020U, 0x00000020U, 0x00008000U, 0x80000000U, 0x00008020U, 0x80108000U, 0x00100000U, 0x80000020U, 0x00100020U, 0x80008020U, 0x80000020U, 0x00100020U, 0x00108000U, 0x00000000U, 0x80008000U, 0x00008020U, 0x80000000U, 0x80100020U, 0x80108020U, 0x00108000U };
        private uint[] SB3 = new[] { 0x00000208U, 0x08020200U, 0x00000000U, 0x08020008U, 0x08000200U, 0x00000000U, 0x00020208U, 0x08000200U, 0x00020008U, 0x08000008U, 0x08000008U, 0x00020000U, 0x08020208U, 0x00020008U, 0x08020000U, 0x00000208U, 0x08000000U, 0x00000008U, 0x08020200U, 0x00000200U, 0x00020200U, 0x08020000U, 0x08020008U, 0x00020208U, 0x08000208U, 0x00020200U, 0x00020000U, 0x08000208U, 0x00000008U, 0x08020208U, 0x00000200U, 0x08000000U, 0x08020200U, 0x08000000U, 0x00020008U, 0x00000208U, 0x00020000U, 0x08020200U, 0x08000200U, 0x00000000U, 0x00000200U, 0x00020008U, 0x08020208U, 0x08000200U, 0x08000008U, 0x00000200U, 0x00000000U, 0x08020008U, 0x08000208U, 0x00020000U, 0x08000000U, 0x08020208U, 0x00000008U, 0x00020208U, 0x00020200U, 0x08000008U, 0x08020000U, 0x08000208U, 0x00000208U, 0x08020000U, 0x00020208U, 0x00000008U, 0x08020008U, 0x00020200U };
        private uint[] SB4 = new[] { 0x00802001U, 0x00002081U, 0x00002081U, 0x00000080U, 0x00802080U, 0x00800081U, 0x00800001U, 0x00002001U, 0x00000000U, 0x00802000U, 0x00802000U, 0x00802081U, 0x00000081U, 0x00000000U, 0x00800080U, 0x00800001U, 0x00000001U, 0x00002000U, 0x00800000U, 0x00802001U, 0x00000080U, 0x00800000U, 0x00002001U, 0x00002080U, 0x00800081U, 0x00000001U, 0x00002080U, 0x00800080U, 0x00002000U, 0x00802080U, 0x00802081U, 0x00000081U, 0x00800080U, 0x00800001U, 0x00802000U, 0x00802081U, 0x00000081U, 0x00000000U, 0x00000000U, 0x00802000U, 0x00002080U, 0x00800080U, 0x00800081U, 0x00000001U, 0x00802001U, 0x00002081U, 0x00002081U, 0x00000080U, 0x00802081U, 0x00000081U, 0x00000001U, 0x00002000U, 0x00800001U, 0x00002001U, 0x00802080U, 0x00800081U, 0x00002001U, 0x00002080U, 0x00800000U, 0x00802001U, 0x00000080U, 0x00800000U, 0x00002000U, 0x00802080U };
        private uint[] SB5 = new[] { 0x00000100U, 0x02080100U, 0x02080000U, 0x42000100U, 0x00080000U, 0x00000100U, 0x40000000U, 0x02080000U, 0x40080100U, 0x00080000U, 0x02000100U, 0x40080100U, 0x42000100U, 0x42080000U, 0x00080100U, 0x40000000U, 0x02000000U, 0x40080000U, 0x40080000U, 0x00000000U, 0x40000100U, 0x42080100U, 0x42080100U, 0x02000100U, 0x42080000U, 0x40000100U, 0x00000000U, 0x42000000U, 0x02080100U, 0x02000000U, 0x42000000U, 0x00080100U, 0x00080000U, 0x42000100U, 0x00000100U, 0x02000000U, 0x40000000U, 0x02080000U, 0x42000100U, 0x40080100U, 0x02000100U, 0x40000000U, 0x42080000U, 0x02080100U, 0x40080100U, 0x00000100U, 0x02000000U, 0x42080000U, 0x42080100U, 0x00080100U, 0x42000000U, 0x42080100U, 0x02080000U, 0x00000000U, 0x40080000U, 0x42000000U, 0x00080100U, 0x02000100U, 0x40000100U, 0x00080000U, 0x00000000U, 0x40080000U, 0x02080100U, 0x40000100U };
        private uint[] SB6 = new[] { 0x20000010U, 0x20400000U, 0x00004000U, 0x20404010U, 0x20400000U, 0x00000010U, 0x20404010U, 0x00400000U, 0x20004000U, 0x00404010U, 0x00400000U, 0x20000010U, 0x00400010U, 0x20004000U, 0x20000000U, 0x00004010U, 0x00000000U, 0x00400010U, 0x20004010U, 0x00004000U, 0x00404000U, 0x20004010U, 0x00000010U, 0x20400010U, 0x20400010U, 0x00000000U, 0x00404010U, 0x20404000U, 0x00004010U, 0x00404000U, 0x20404000U, 0x20000000U, 0x20004000U, 0x00000010U, 0x20400010U, 0x00404000U, 0x20404010U, 0x00400000U, 0x00004010U, 0x20000010U, 0x00400000U, 0x20004000U, 0x20000000U, 0x00004010U, 0x20000010U, 0x20404010U, 0x00404000U, 0x20400000U, 0x00404010U, 0x20404000U, 0x00000000U, 0x20400010U, 0x00000010U, 0x00004000U, 0x20400000U, 0x00404010U, 0x00004000U, 0x00400010U, 0x20004010U, 0x00000000U, 0x20404000U, 0x20000000U, 0x00400010U, 0x20004010U };
        private uint[] SB7 = new[] { 0x00200000U, 0x04200002U, 0x04000802U, 0x00000000U, 0x00000800U, 0x04000802U, 0x00200802U, 0x04200800U, 0x04200802U, 0x00200000U, 0x00000000U, 0x04000002U, 0x00000002U, 0x04000000U, 0x04200002U, 0x00000802U, 0x04000800U, 0x00200802U, 0x00200002U, 0x04000800U, 0x04000002U, 0x04200000U, 0x04200800U, 0x00200002U, 0x04200000U, 0x00000800U, 0x00000802U, 0x04200802U, 0x00200800U, 0x00000002U, 0x04000000U, 0x00200800U, 0x04000000U, 0x00200800U, 0x00200000U, 0x04000802U, 0x04000802U, 0x04200002U, 0x04200002U, 0x00000002U, 0x00200002U, 0x04000000U, 0x04000800U, 0x00200000U, 0x04200800U, 0x00000802U, 0x00200802U, 0x04200800U, 0x00000802U, 0x04000002U, 0x04200802U, 0x04200000U, 0x00200800U, 0x00000000U, 0x00000002U, 0x04200802U, 0x00000000U, 0x00200802U, 0x04200000U, 0x00000800U, 0x04000002U, 0x04000800U, 0x00000800U, 0x00200002U };
        private uint[] SB8 = new[] { 0x10001040U, 0x00001000U, 0x00040000U, 0x10041040U, 0x10000000U, 0x10001040U, 0x00000040U, 0x10000000U, 0x00040040U, 0x10040000U, 0x10041040U, 0x00041000U, 0x10041000U, 0x00041040U, 0x00001000U, 0x00000040U, 0x10040000U, 0x10000040U, 0x10001000U, 0x00001040U, 0x00041000U, 0x00040040U, 0x10040040U, 0x10041000U, 0x00001040U, 0x00000000U, 0x00000000U, 0x10040040U, 0x10000040U, 0x10001000U, 0x00041040U, 0x00040000U, 0x00041040U, 0x00040000U, 0x10041000U, 0x00001000U, 0x00000040U, 0x10040040U, 0x00001000U, 0x00041040U, 0x10001000U, 0x00000040U, 0x10000040U, 0x10040000U, 0x10040040U, 0x10000000U, 0x00040000U, 0x10001040U, 0x00000000U, 0x10041040U, 0x00040040U, 0x10000040U, 0x10040000U, 0x10001000U, 0x10001040U, 0x00000000U, 0x10041040U, 0x00041000U, 0x00041000U, 0x00001040U, 0x00001040U, 0x00040040U, 0x10000000U, 0x10041000U };
        // PC1: left and right halves bit-swap
        private uint[] LHs = new[] { 0x00000000U, 0x00000001U, 0x00000100U, 0x00000101U, 0x00010000U, 0x00010001U, 0x00010100U, 0x00010101U, 0x01000000U, 0x01000001U, 0x01000100U, 0x01000101U, 0x01010000U, 0x01010001U, 0x01010100U, 0x01010101U };
        private uint[] RHs = new[] { 0x00000000U, 0x01000000U, 0x00010000U, 0x01010000U, 0x00000100U, 0x01000100U, 0x00010100U, 0x01010100U, 0x00000001U, 0x01000001U, 0x00010001U, 0x01010001U, 0x00000101U, 0x01000101U, 0x00010101U, 0x01010101U };
        // platform-independant 32-bit integer manipulation macros

        private void GET_UINT32(ref uint n, ref byte[] b, ref int i)
        {
            n = Conversions.ToUInteger(b[i]) << 24 | Conversions.ToUInteger(b[i + 1]) << 16 | Conversions.ToUInteger(b[i + 2]) << 8 | Conversions.ToUInteger(b[i + 3]);


        }

        private void PUT_UINT32(ref uint n, ref byte[] b, ref int i)
        {
            b[i] = Conversions.ToByte(n >> 24 & 0xFFU);
            b[i + 1] = Conversions.ToByte(n >> 16 & 0xFFU);
            b[i + 2] = Conversions.ToByte(n >> 8 & 0xFFU);
            b[i + 3] = Conversions.ToByte(n & 0xFFU);
        }

        // Initial Permutation macro

        private void DES_IP(ref uint X, ref uint Y, ref uint T)
        {
            T = (X >> 4 ^ Y) & 0x0F0F0F0FU;
            Y = Y ^ T;
            X = X ^ T << 4;
            T = (X >> 16 ^ Y) & 0x0000FFFFU;
            Y = Y ^ T;
            X = X ^ T << 16;
            T = (Y >> 2 ^ X) & 0x33333333U;
            X = X ^ T;
            Y = Y ^ T << 2;
            T = (Y >> 8 ^ X) & 0x00FF00FFU;
            X = X ^ T;
            Y = Y ^ T << 8;
            Y = (Y << 1 | Y >> 31) & 0xFFFFFFFFU;
            T = (X ^ Y) & 0xAAAAAAAAU;
            Y = Y ^ T;
            X = X ^ T;
            X = (X << 1 | X >> 31) & 0xFFFFFFFFU;
        }

        // Final Permutation macro

        private void DES_FP(ref uint X, ref uint Y, ref uint T)
        {
            X = (X << 31 | X >> 1) & 0xFFFFFFFFU;
            T = (X ^ Y) & 0xAAAAAAAAU;
            X = X ^ T;
            Y = Y ^ T;
            Y = (Y << 31 | Y >> 1) & 0xFFFFFFFFU;
            T = (Y >> 8 ^ X) & 0x00FF00FFU;
            X = X ^ T;
            Y = Y ^ T << 8;
            T = (Y >> 2 ^ X) & 0x33333333U;
            X = X ^ T;
            Y = Y ^ T << 2;
            T = (X >> 16 ^ Y) & 0x0000FFFFU;
            Y = Y ^ T;
            X = X ^ T << 16;
            T = (X >> 4 ^ Y) & 0x0F0F0F0FU;
            Y = Y ^ T;
            X = X ^ T << 4;
        }

        // DES round macro
        // init nSK as -1
        private void DES_ROUND(ref uint X, ref uint Y, ref uint T, ref uint[] SK, ref int nSK)
        {
            nSK += 1;
            T = SK[nSK] ^ X;
            Y = Y ^ SB8[Conversions.ToInteger(T & 0x3FU)] ^ SB6[Conversions.ToInteger(T >> 8 & 0x3FU)] ^ SB4[Conversions.ToInteger(T >> 16 & 0x3FU)] ^ SB2[Conversions.ToInteger(T >> 24 & 0x3FU)];


            nSK += 1;
            T = SK[nSK] ^ (X << 28 | X >> 4);
            Y = Y ^ SB7[Conversions.ToInteger(T & 0x3FU)] ^ SB5[Conversions.ToInteger(T >> 8 & 0x3FU)] ^ SB3[Conversions.ToInteger(T >> 16 & 0x3FU)] ^ SB1[Conversions.ToInteger(T >> 24 & 0x3FU)];


        }

        // DES key schedule
        // nSK will be -1 for DES, 31 for 2nd part of 3DES
        private int des_main_ks(ref uint[] SK, ref byte[] key, ref int nSK)
        {
            int i;
            uint X = default, Y = default, T;
            int argi = 0;
            GET_UINT32(ref X, ref key, ref argi);
            int argi1 = 4;
            GET_UINT32(ref Y, ref key, ref argi1);

            // Permuted Choice 1

            T = (Y >> 4 ^ X) & 0x0F0F0F0FU;
            X = X ^ T;
            Y = Y ^ T << 4;
            T = (Y ^ X) & 0x10101010U;
            X = X ^ T;
            Y = Y ^ T;
            X = LHs[Conversions.ToInteger(X & 0x0000000FU)] << 3 | LHs[Conversions.ToInteger(X >> 8 & 0x0000000FU)] << 2 | LHs[Conversions.ToInteger(X >> 16 & 0x0000000FU)] << 1 | LHs[Conversions.ToInteger(X >> 24 & 0x0000000FU)] | LHs[Conversions.ToInteger(X >> 5 & 0x0000000FU)] << 7 | LHs[Conversions.ToInteger(X >> 13 & 0x0000000FU)] << 6 | LHs[Conversions.ToInteger(X >> 21 & 0x0000000FU)] << 5 | LHs[Conversions.ToInteger(X >> 29 & 0x0000000FU)] << 4;


            Y = RHs[Conversions.ToInteger(Y >> 1 & 0x0000000FU)] << 3 | RHs[Conversions.ToInteger(Y >> 9 & 0x0000000FU)] << 2 | RHs[Conversions.ToInteger(Y >> 17 & 0x0000000FU)] << 1 | RHs[Conversions.ToInteger(Y >> 25 & 0x0000000FU)] | RHs[Conversions.ToInteger(Y >> 4 & 0x0000000FU)] << 7 | RHs[Conversions.ToInteger(Y >> 12 & 0x0000000FU)] << 6 | RHs[Conversions.ToInteger(Y >> 20 & 0x0000000FU)] << 5 | RHs[Conversions.ToInteger(Y >> 28 & 0x0000000FU)] << 4;


            X = X & 0x0FFFFFFFU;
            Y = Y & 0x0FFFFFFFU;

            // calculate subkeys

            for (i = 0; i <= 15; i++)
            {
                if (i < 2 || i == 8 || i == 15)
                {
                    X = (X << 1 | X >> 27) & 0x0FFFFFFFU;
                    Y = (Y << 1 | Y >> 27) & 0x0FFFFFFFU;
                }
                else
                {
                    X = (X << 2 | X >> 26) & 0x0FFFFFFFU;
                    Y = (Y << 2 | Y >> 26) & 0x0FFFFFFFU;
                }

                nSK += 1;
                SK[nSK] = X << 4 & 0x24000000U | X << 28 & 0x10000000U | X << 14 & 0x08000000U | X << 18 & 0x02080000U | X << 6 & 0x01000000U | X << 9 & 0x00200000U | X >> 1 & 0x00100000U | X << 10 & 0x00040000U | X << 2 & 0x00020000U | X >> 10 & 0x00010000U | Y >> 13 & 0x00002000U | Y >> 4 & 0x00001000U | Y << 6 & 0x00000800U | Y >> 1 & 0x00000400U | Y >> 14 & 0x00000200U | Y & 0x00000100U | Y >> 5 & 0x00000020U | Y >> 10 & 0x00000010U | Y >> 3 & 0x00000008U | Y >> 18 & 0x00000004U | Y >> 26 & 0x00000002U | Y >> 24 & 0x00000001U;









                nSK += 1;
                SK[nSK] = X << 15 & 0x20000000U | X << 17 & 0x10000000U | X << 10 & 0x08000000U | X << 22 & 0x04000000U | X >> 2 & 0x02000000U | X << 1 & 0x01000000U | X << 16 & 0x00200000U | X << 11 & 0x00100000U | X << 3 & 0x00080000U | X >> 6 & 0x00040000U | X << 15 & 0x00020000U | X >> 4 & 0x00010000U | Y >> 2 & 0x00002000U | Y << 8 & 0x00001000U | Y >> 14 & 0x00000808U | Y >> 9 & 0x00000400U | Y & 0x00000200U | Y << 7 & 0x00000100U | Y >> 7 & 0x00000020U | Y >> 3 & 0x00000011U | Y << 2 & 0x00000004U | Y >> 21 & 0x00000002U;









            }

            return 0;
        }

        // DES encryption subkeys 
        // esk(31)
        // dsk(31)
        private partial struct des_context
        {
            public uint[] esk;
            public uint[] dsk;
        }

        // Triple-DES encryption subkeys
        // esk(95)
        // dsk(95)
        private partial struct des3_context
        {
            public uint[] esk;
            public uint[] dsk;
        }

        private int des_set_key(ref des_context ctx, ref byte[] key)
        {
            int i;

            // setup encryption subkeys

            int argnSK = -1;
            des_main_ks(ref ctx.esk, ref key, ref argnSK);

            // setup decryption subkeys

            for (i = 0; i <= 31; i += 2)
            {
                ctx.dsk[i] = ctx.esk[30 - i];
                ctx.dsk[i + 1] = ctx.esk[31 - i];
            }

            return 0;
        }

        // DES 64-bit block encryption/decryption

        private void des_crypt(ref uint[] SK, ref byte[] input, ref byte[] output)
        {
            uint X = default, Y = default, T = default;
            int argi = 0;
            GET_UINT32(ref X, ref input, ref argi);
            int argi1 = 4;
            GET_UINT32(ref Y, ref input, ref argi1);
            DES_IP(ref X, ref Y, ref T);
            int nSK = -1;
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_FP(ref Y, ref X, ref T);
            int argi2 = 0;
            PUT_UINT32(ref Y, ref output, ref argi2);
            int argi3 = 4;
            PUT_UINT32(ref X, ref output, ref argi3);
        }

        private void des_encrypt(ref des_context ctx, ref byte[] input, ref byte[] output)
        {
            des_crypt(ref ctx.esk, ref input, ref output);
        }

        private void des_decrypt(ref des_context ctx, ref byte[] input, ref byte[] output)
        {
            des_crypt(ref ctx.dsk, ref input, ref output);
        }

        // Triple-DES key schedule 

        private int des3_set_2keys(ref des3_context ctx, ref byte[] key1, ref byte[] key2)
        {
            int i;
            int argnSK = -1;
            des_main_ks(ref ctx.esk, ref key1, ref argnSK);
            int argnSK1 = 31;
            des_main_ks(ref ctx.dsk, ref key2, ref argnSK1);
            for (i = 0; i <= 31; i += 2)
            {
                ctx.dsk[i] = ctx.esk[30 - i];
                ctx.dsk[i + 1] = ctx.esk[31 - i];
                ctx.esk[i + 32] = ctx.dsk[62 - i];
                ctx.esk[i + 33] = ctx.dsk[63 - i];
                ctx.esk[i + 64] = ctx.esk[i];
                ctx.esk[i + 65] = ctx.esk[1 + i];
                ctx.dsk[i + 64] = ctx.dsk[i];
                ctx.dsk[i + 65] = ctx.dsk[1 + i];
            }

            return 0;
        }

        // Triple-DES 64-bit block encryption/decryption 

        private void des3_crypt(ref uint[] SK, ref byte[] input, ref byte[] output)
        {
            uint X = default, Y = default, T = default;
            int argi = 0;
            GET_UINT32(ref X, ref input, ref argi);
            int argi1 = 4;
            GET_UINT32(ref Y, ref input, ref argi1);
            DES_IP(ref X, ref Y, ref T);
            int nSK = -1;

            // encrypt
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);

            // decrypt
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);

            // encrypt
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_FP(ref Y, ref X, ref T);
            int argi2 = 0;
            PUT_UINT32(ref Y, ref output, ref argi2);
            int argi3 = 4;
            PUT_UINT32(ref X, ref output, ref argi3);
        }

        private void des3_encrypt(ref des3_context ctx, ref byte[] input, ref byte[] output)
        {
            des3_crypt(ref ctx.esk, ref input, ref output);
        }

        private void des3_decrypt(ref des3_context ctx, ref byte[] input, ref byte[] output)
        {
            des3_crypt(ref ctx.dsk, ref input, ref output);
        }

        public void encrypt_3des(byte[] key, byte[] input, int inputLength, ref byte[] output, ref int outputLength)
        {
            var in_ = new byte[8];
            var @out = new byte[8];
            des3_context ctx;
            ctx.dsk = new uint[96];
            ctx.esk = new uint[96];
            int i = 0;
            int j = 0;
            byte[] temp;
            temp = output;

            // Set encryption keys
            var key2 = new byte[8];
            Array.Copy(key, 8, key2, 0, 8);
            des3_set_2keys(ref ctx, ref key, ref key2);

            // clear buffers
            // (not necessary)

            // do for each 8 byte block of input
            var loopTo = inputLength / (double)8 - 1;
            for (i = 0; i <= loopTo; i++)
            {
                // copy 8 bytes from input buffer to in
                Array.Copy(input, i * 8, in_, 0, 8);

                // xor with ciphered block -1 
                for (j = 0; j <= 7; j++)
                    in_[j] = (byte)(in_[j] ^ @out[j]);

                // 3DES encryption
                des3_encrypt(ref ctx, ref in_, ref @out);

                // copy encrypted block to output
                Array.Copy(@out, 0, temp, i * 8, 8);
            }

            outputLength = inputLength;
        }

        public void decrypt_3des(byte[] key, byte[] input, int inputLength, ref byte[] output, ref int outputLength)
        {
            des3_context ctx;
            ctx.dsk = new uint[96];
            ctx.esk = new uint[96];
            var in_ = new byte[8];
            var @out = new byte[8];
            var in2 = new byte[8];
            byte[] temp;
            int i = 0;
            int j = 0;
            temp = output;

            // Set encryption keys
            var key2 = new byte[8];
            Array.Copy(key, 8, key2, 0, 8);
            des3_set_2keys(ref ctx, ref key, ref key2);

            // clear buffers
            // (not necessary)

            // do for each 8 byte block of input
            var loopTo = inputLength / (double)8 - 1;
            for (i = 0; i <= loopTo; i++)
            {
                // copy 8 bytes from input buffer to in
                Array.Copy(input, i * 8, in_, 0, 8);

                // 3DES encryption
                des3_decrypt(ref ctx, ref in_, ref @out);

                // xor with ciphered block -1 
                for (j = 0; j <= 7; j++)
                    @out[j] = (byte)(@out[j] ^ in2[j]);
                Array.Copy(input, i * 8, in2, 0, 8);

                // copy encrypted block to output
                Array.Copy(@out, 0, temp, i * 8, 8);
            }

            outputLength = inputLength;
        }

        public void encrypt_des(byte[] key, byte[] input, int inputLength, ref byte[] output, ref int outputLength)
        {
            var in_ = new byte[8];
            var @out = new byte[8];
            des_context ctx;
            ctx.dsk = new uint[32];
            ctx.esk = new uint[32];
            int i = 0;
            int j = 0;
            byte[] temp;
            temp = output;

            // Set encryption keys
            des_set_key(ref ctx, ref key);

            // clear buffers
            // (not necessary)

            // do for each 8 byte block of input
            var loopTo = inputLength / (double)8 - 1;
            for (i = 0; i <= loopTo; i++)
            {
                // copy 8 bytes from input buffer to in
                Array.Copy(input, i * 8, in_, 0, 8);

                // xor with ciphered block -1 
                for (j = 0; j <= 7; j++)
                    in_[j] = (byte)(in_[j] ^ @out[j]);

                // DES encryption
                des_encrypt(ref ctx, ref in_, ref @out);

                // copy encrypted block to output
                Array.Copy(@out, 0, temp, i * 8, 8);
            }

            outputLength = inputLength;
        }

        public void decrypt_des(byte[] key, byte[] input, int inputLength, ref byte[] output, ref int outputLength)
        {
            des_context ctx;
            ctx.dsk = new uint[32];
            ctx.esk = new uint[32];
            var in_ = new byte[8];
            var @out = new byte[8];
            var in2 = new byte[8];
            byte[] temp;
            int i = 0;
            int j = 0;
            temp = output;

            // Set encryption keys
            des_set_key(ref ctx, ref key);

            // clear buffers
            // (not necessary)

            // do for each 8 byte block of input
            var loopTo = inputLength / (double)8 - 1;
            for (i = 0; i <= loopTo; i++)
            {
                // copy 8 bytes from input buffer to in
                Array.Copy(input, i * 8, in_, 0, 8);

                // DES encryption
                des_decrypt(ref ctx, ref in_, ref @out);

                // xor with ciphered block -1 
                for (j = 0; j <= 7; j++)
                    @out[j] = (byte)(@out[j] ^ in2[j]);
                Array.Copy(input, i * 8, in2, 0, 8);

                // copy encrypted block to output
                Array.Copy(@out, 0, temp, i * 8, 8);
            }

            outputLength = inputLength;
        }
    }
}
