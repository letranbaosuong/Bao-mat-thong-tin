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
        //the eight DES S-boxes
        UInt32[] SB1 = {
            0x01010400, 0x00000000, 0x00010000, 0x01010404,
            0x01010004, 0x00010404, 0x00000004, 0x00010000,
            0x00000400, 0x01010400, 0x01010404, 0x00000400,
            0x01000404, 0x01010004, 0x01000000, 0x00000004,
            0x00000404, 0x01000400, 0x01000400, 0x00010400,
            0x00010400, 0x01010000, 0x01010000, 0x01000404,
            0x00010004, 0x01000004, 0x01000004, 0x00010004,
            0x00000000, 0x00000404, 0x00010404, 0x01000000,
            0x00010000, 0x01010404, 0x00000004, 0x01010000,
            0x01010400, 0x01000000, 0x01000000, 0x00000400,
            0x01010004, 0x00010000, 0x00010400, 0x01000004,
            0x00000400, 0x00000004, 0x01000404, 0x00010404,
            0x01010404, 0x00010004, 0x01010000, 0x01000404,
            0x01000004, 0x00000404, 0x00010404, 0x01010400,
            0x00000404, 0x01000400, 0x01000400, 0x00000000,
            0x00010004, 0x00010400, 0x00000000, 0x01010004
        };

        UInt32[] SB2 = {
            0x80108020, 0x80008000, 0x00008000, 0x00108020,
            0x00100000, 0x00000020, 0x80100020, 0x80008020,
            0x80000020, 0x80108020, 0x80108000, 0x80000000,
            0x80008000, 0x00100000, 0x00000020, 0x80100020,
            0x00108000, 0x00100020, 0x80008020, 0x00000000,
            0x80000000, 0x00008000, 0x00108020, 0x80100000,
            0x00100020, 0x80000020, 0x00000000, 0x00108000,
            0x00008020, 0x80108000, 0x80100000, 0x00008020,
            0x00000000, 0x00108020, 0x80100020, 0x00100000,
            0x80008020, 0x80100000, 0x80108000, 0x00008000,
            0x80100000, 0x80008000, 0x00000020, 0x80108020,
            0x00108020, 0x00000020, 0x00008000, 0x80000000,
            0x00008020, 0x80108000, 0x00100000, 0x80000020,
            0x00100020, 0x80008020, 0x80000020, 0x00100020,
            0x00108000, 0x00000000, 0x80008000, 0x00008020,
            0x80000000, 0x80100020, 0x80108020, 0x00108000
        };

        UInt32[] SB3 = {
            0x00000208, 0x08020200, 0x00000000, 0x08020008,
            0x08000200, 0x00000000, 0x00020208, 0x08000200,
            0x00020008, 0x08000008, 0x08000008, 0x00020000,
            0x08020208, 0x00020008, 0x08020000, 0x00000208,
            0x08000000, 0x00000008, 0x08020200, 0x00000200,
            0x00020200, 0x08020000, 0x08020008, 0x00020208,
            0x08000208, 0x00020200, 0x00020000, 0x08000208,
            0x00000008, 0x08020208, 0x00000200, 0x08000000,
            0x08020200, 0x08000000, 0x00020008, 0x00000208,
            0x00020000, 0x08020200, 0x08000200, 0x00000000,
            0x00000200, 0x00020008, 0x08020208, 0x08000200,
            0x08000008, 0x00000200, 0x00000000, 0x08020008,
            0x08000208, 0x00020000, 0x08000000, 0x08020208,
            0x00000008, 0x00020208, 0x00020200, 0x08000008,
            0x08020000, 0x08000208, 0x00000208, 0x08020000,
            0x00020208, 0x00000008, 0x08020008, 0x00020200
        };

        UInt32[] SB4 = {
            0x00802001, 0x00002081, 0x00002081, 0x00000080,
            0x00802080, 0x00800081, 0x00800001, 0x00002001,
            0x00000000, 0x00802000, 0x00802000, 0x00802081,
            0x00000081, 0x00000000, 0x00800080, 0x00800001,
            0x00000001, 0x00002000, 0x00800000, 0x00802001,
            0x00000080, 0x00800000, 0x00002001, 0x00002080,
            0x00800081, 0x00000001, 0x00002080, 0x00800080,
            0x00002000, 0x00802080, 0x00802081, 0x00000081,
            0x00800080, 0x00800001, 0x00802000, 0x00802081,
            0x00000081, 0x00000000, 0x00000000, 0x00802000,
            0x00002080, 0x00800080, 0x00800081, 0x00000001,
            0x00802001, 0x00002081, 0x00002081, 0x00000080,
            0x00802081, 0x00000081, 0x00000001, 0x00002000,
            0x00800001, 0x00002001, 0x00802080, 0x00800081,
            0x00002001, 0x00002080, 0x00800000, 0x00802001,
            0x00000080, 0x00800000, 0x00002000, 0x00802080
        };

        UInt32[] SB5 = {
            0x00000100, 0x02080100, 0x02080000, 0x42000100,
            0x00080000, 0x00000100, 0x40000000, 0x02080000,
            0x40080100, 0x00080000, 0x02000100, 0x40080100,
            0x42000100, 0x42080000, 0x00080100, 0x40000000,
            0x02000000, 0x40080000, 0x40080000, 0x00000000,
            0x40000100, 0x42080100, 0x42080100, 0x02000100,
            0x42080000, 0x40000100, 0x00000000, 0x42000000,
            0x02080100, 0x02000000, 0x42000000, 0x00080100,
            0x00080000, 0x42000100, 0x00000100, 0x02000000,
            0x40000000, 0x02080000, 0x42000100, 0x40080100,
            0x02000100, 0x40000000, 0x42080000, 0x02080100,
            0x40080100, 0x00000100, 0x02000000, 0x42080000,
            0x42080100, 0x00080100, 0x42000000, 0x42080100,
            0x02080000, 0x00000000, 0x40080000, 0x42000000,
            0x00080100, 0x02000100, 0x40000100, 0x00080000,
            0x00000000, 0x40080000, 0x02080100, 0x40000100
        };

        UInt32[] SB6 = {
            0x20000010, 0x20400000, 0x00004000, 0x20404010,
            0x20400000, 0x00000010, 0x20404010, 0x00400000,
            0x20004000, 0x00404010, 0x00400000, 0x20000010,
            0x00400010, 0x20004000, 0x20000000, 0x00004010,
            0x00000000, 0x00400010, 0x20004010, 0x00004000,
            0x00404000, 0x20004010, 0x00000010, 0x20400010,
            0x20400010, 0x00000000, 0x00404010, 0x20404000,
            0x00004010, 0x00404000, 0x20404000, 0x20000000,
            0x20004000, 0x00000010, 0x20400010, 0x00404000,
            0x20404010, 0x00400000, 0x00004010, 0x20000010,
            0x00400000, 0x20004000, 0x20000000, 0x00004010,
            0x20000010, 0x20404010, 0x00404000, 0x20400000,
            0x00404010, 0x20404000, 0x00000000, 0x20400010,
            0x00000010, 0x00004000, 0x20400000, 0x00404010,
            0x00004000, 0x00400010, 0x20004010, 0x00000000,
            0x20404000, 0x20000000, 0x00400010, 0x20004010
        };

        UInt32[] SB7 = {
            0x00200000, 0x04200002, 0x04000802, 0x00000000,
            0x00000800, 0x04000802, 0x00200802, 0x04200800,
            0x04200802, 0x00200000, 0x00000000, 0x04000002,
            0x00000002, 0x04000000, 0x04200002, 0x00000802,
            0x04000800, 0x00200802, 0x00200002, 0x04000800,
            0x04000002, 0x04200000, 0x04200800, 0x00200002,
            0x04200000, 0x00000800, 0x00000802, 0x04200802,
            0x00200800, 0x00000002, 0x04000000, 0x00200800,
            0x04000000, 0x00200800, 0x00200000, 0x04000802,
            0x04000802, 0x04200002, 0x04200002, 0x00000002,
            0x00200002, 0x04000000, 0x04000800, 0x00200000,
            0x04200800, 0x00000802, 0x00200802, 0x04200800,
            0x00000802, 0x04000002, 0x04200802, 0x04200000,
            0x00200800, 0x00000000, 0x00000002, 0x04200802,
            0x00000000, 0x00200802, 0x04200000, 0x00000800,
            0x04000002, 0x04000800, 0x00000800, 0x00200002
        };

        UInt32[] SB8 = {
            0x10001040, 0x00001000, 0x00040000, 0x10041040,
            0x10000000, 0x10001040, 0x00000040, 0x10000000,
            0x00040040, 0x10040000, 0x10041040, 0x00041000,
            0x10041000, 0x00041040, 0x00001000, 0x00000040,
            0x10040000, 0x10000040, 0x10001000, 0x00001040,
            0x00041000, 0x00040040, 0x10040040, 0x10041000,
            0x00001040, 0x00000000, 0x00000000, 0x10040040,
            0x10000040, 0x10001000, 0x00041040, 0x00040000,
            0x00041040, 0x00040000, 0x10041000, 0x00001000,
            0x00000040, 0x10040040, 0x00001000, 0x00041040,
            0x10001000, 0x00000040, 0x10000040, 0x10040000,
            0x10040040, 0x10000000, 0x00040000, 0x10001040,
            0x00000000, 0x10041040, 0x00040040, 0x10000040,
            0x10040000, 0x10001000, 0x10001040, 0x00000000,
            0x10041040, 0x00041000, 0x00041000, 0x00001040,
            0x00001040, 0x00040040, 0x10000000, 0x10041000
        };

        //PC1: left and right halves bit-swap
        UInt32[] LHs = {
            0x00000000, 0x00000001, 0x00000100, 0x00000101,
            0x00010000, 0x00010001, 0x00010100, 0x00010101,
            0x01000000, 0x01000001, 0x01000100, 0x01000101,
            0x01010000, 0x01010001, 0x01010100, 0x01010101
        };

        UInt32[] RHs = {
            0x00000000, 0x01000000, 0x00010000, 0x01010000,
            0x00000100, 0x01000100, 0x00010100, 0x01010100,
            0x00000001, 0x01000001, 0x00010001, 0x01010001,
            0x00000101, 0x01000101, 0x00010101, 0x01010101
        };

        //platform-independant 32-bit integer manipulation macros
        private void GET_UINT32(ref UInt32 n, ref byte[] b, int i)
        {
            n = ((UInt32)(b[i]) << 24) | (UInt32)((b[i + 1]) << 16) | (UInt32)((b[i + 2]) << 8) | (UInt32)((b[i + 3]));
        }

        private void PUT_UINT32(ref UInt32 n, ref byte[] b, int i)
        {
            b[i] = (byte)((n >> 24) & 0xFF);
            b[i + 1] = (byte)((n >> 16) & 0xFF);
            b[i + 2] = (byte)((n >> 8) & 0xFF);
            b[i + 3] = (byte)((n) & 0xFF);
        }

        //Initial Permutation macro

        private void DES_IP(ref UInt32 X, ref UInt32 Y, ref UInt32 T)
        {
            T = ((X >> 4) ^ Y) & 0x0F0F0F0F; Y = Y ^ T; X = X ^ (T << 4);
            T = ((X >> 16) ^ Y) & 0x0000FFFF; Y = Y ^ T; X = X ^ (T << 16);
            T = ((Y >> 2) ^ X) & 0x33333333; X = X ^ T; Y = Y ^ (T << 2);
            T = ((Y >> 8) ^ X) & 0x00FF00FF; X = X ^ T; Y = Y ^ (T << 8);
            Y = ((Y << 1) | (Y >> 31)) & 0xFFFFFFFF;
            T = (X ^ Y) & 0xAAAAAAAA; Y = Y ^ T; X = X ^ T;
            X = ((X << 1) | (X >> 31)) & 0xFFFFFFFF;
        }

        //Final Permutation macro

        private void DES_FP(ref UInt32 X, ref UInt32 Y, ref UInt32 T)
        {
            X = ((X << 31) | (X >> 1)) & 0xFFFFFFFF;
            T = (X ^ Y) & 0xAAAAAAAA; X = X ^ T; Y = Y ^ T;
            Y = ((Y << 31) | (Y >> 1)) & 0xFFFFFFFF;
            T = ((Y >> 8) ^ X) & 0x00FF00FF; X = X ^ T; Y = Y ^ (T << 8);
            T = ((Y >> 2) ^ X) & 0x33333333; X = X ^ T; Y = Y ^ (T << 2);
            T = ((X >> 16) ^ Y) & 0x0000FFFF; Y = Y ^ T; X = X ^ (T << 16);
            T = ((X >> 4) ^ Y) & 0x0F0F0F0F; Y = Y ^ T; X = X ^ (T << 4);
        }

        //DES round macro
        //init nSK as -1

        private void DES_ROUND(ref UInt32 X, ref UInt32 Y, ref UInt32 T, ref UInt32[] SK, ref int nSK)
        {
            nSK += 1;
            T = SK[nSK] ^ X;
            Y = Y ^ SB8[(T) & 0x3F] ^
                      SB6[(T >> 8) & 0x3F] ^
                      SB4[(T >> 16) & 0x3F] ^
                      SB2[(T >> 24) & 0x3F];

            nSK += 1;
            T = SK[nSK] ^ ((X << 28) | (X >> 4));
            Y = Y ^ SB7[(T) & 0x3F] ^
                      SB5[(T >> 8) & 0x3F] ^
                      SB3[(T >> 16) & 0x3F] ^
                      SB1[(T >> 24) & 0x3F];
        }

        //DES key schedule
        //nSK will be -1 for DES, 31 for 2nd part of 3DES

        private int des_main_ks(ref UInt32[] SK, ref byte[] key, int nSK)
        {
            int i;
            UInt32 X = 0, Y = 0, T = 0;
            GET_UINT32(ref X, ref key, 0);
            GET_UINT32(ref Y, ref key, 4);

            // Permuted Choice 1

            T = ((Y >> 4) ^ X) & 0x0F0F0F0FU; X = X ^ T; Y = Y ^ (T << 4);
            T = ((Y) ^ X) & 0x10101010U; X = X ^ T; Y = Y ^ (T);

            X = (LHs[(X) & 0x0000000F] << 3) | (LHs[(X >> 8) & 0x0000000F] << 2)
              | (LHs[(X >> 16) & 0x0000000F] << 1) | (LHs[(X >> 24) & 0x0000000F])
              | (LHs[(X >> 5) & 0x0000000F] << 7) | (LHs[(X >> 13) & 0x0000000F] << 6)
              | (LHs[(X >> 21) & 0x0000000F] << 5) | (LHs[(X >> 29) & 0x0000000F] << 4);

            Y = (RHs[(Y >> 1) & 0x0000000F] << 3) | (RHs[(Y >> 9) & 0x0000000F] << 2)
              | (RHs[(Y >> 17) & 0x0000000F] << 1) | (RHs[(Y >> 25) & 0x0000000F])
              | (RHs[(Y >> 4) & 0x0000000F] << 7) | (RHs[(Y >> 12) & 0x0000000F] << 6)
              | (RHs[(Y >> 20) & 0x0000000F] << 5) | (RHs[(Y >> 28) & 0x0000000F] << 4);

            X = X & 0x0FFFFFFFU;
            Y = Y & 0x0FFFFFFFU;

            // calculate subkeys

            for (i = 0; i <= 15; i++)
            {
                if (i < 2 || i == 8 || i == 15)
                {
                    X = ((X << 1) | (X >> 27)) & 0x0FFFFFFFU;
                    Y = ((Y << 1) | (Y >> 27)) & 0x0FFFFFFFU;
                }
                else
                {
                    X = ((X << 2) | (X >> 26)) & 0x0FFFFFFFU;
                    Y = ((Y << 2) | (Y >> 26)) & 0x0FFFFFFFU;
                }

                nSK += 1;
                SK[nSK] = ((X << 4) & 0x24000000) | ((X << 28) & 0x10000000)
                        | ((X << 14) & 0x08000000) | ((X << 18) & 0x02080000)
                        | ((X << 6) & 0x01000000) | ((X << 9) & 0x00200000)
                        | ((X >> 1) & 0x00100000) | ((X << 10) & 0x00040000)
                        | ((X << 2) & 0x00020000) | ((X >> 10) & 0x00010000)
                        | ((Y >> 13) & 0x00002000) | ((Y >> 4) & 0x00001000)
                        | ((Y << 6) & 0x00000800) | ((Y >> 1) & 0x00000400)
                        | ((Y >> 14) & 0x00000200) | ((Y) & 0x00000100)
                        | ((Y >> 5) & 0x00000020) | ((Y >> 10) & 0x00000010)
                        | ((Y >> 3) & 0x00000008) | ((Y >> 18) & 0x00000004)
                        | ((Y >> 26) & 0x00000002) | ((Y >> 24) & 0x00000001);

                nSK += 1;
                SK[nSK] = ((X << 15) & 0x20000000) | ((X << 17) & 0x10000000)
                        | ((X << 10) & 0x08000000) | ((X << 22) & 0x04000000)
                        | ((X >> 2) & 0x02000000) | ((X << 1) & 0x01000000)
                        | ((X << 16) & 0x00200000) | ((X << 11) & 0x00100000)
                        | ((X << 3) & 0x00080000) | ((X >> 6) & 0x00040000)
                        | ((X << 15) & 0x00020000) | ((X >> 4) & 0x00010000)
                        | ((Y >> 2) & 0x00002000) | ((Y << 8) & 0x00001000)
                        | ((Y >> 14) & 0x00000808) | ((Y >> 9) & 0x00000400)
                        | ((Y) & 0x00000200) | ((Y << 7) & 0x00000100)
                        | ((Y >> 7) & 0x00000020) | ((Y >> 3) & 0x00000011)
                        | ((Y << 2) & 0x00000004) | ((Y >> 21) & 0x00000002);
            }

            return 0;
        }

        // DES encryption subkeys 
        // esk(31)
        // dsk(31)

        private struct des_context
        {
            public UInt32[] esk;
            public UInt32[] dsk;
        }

        // Triple-DES encryption subkeys
        // esk(95)
        // dsk(95)
        private struct des3_context
        {
            public UInt32[] esk;
            public UInt32[] dsk;
        }

        private int des_set_key(ref des_context ctx, ref Byte[] key)
        {
            int i;

            // setup encryption subkeys

            des_main_ks(ref ctx.esk, ref key, -1);

            // setup decryption subkeys

            for (i = 0; i <= 31; i += 2)
            {
                ctx.dsk[i] = ctx.esk[30 - i];
                ctx.dsk[i + 1] = ctx.esk[31 - i];
            }

            return 0;
        }

        // DES 64-bit block encryption/decryption

        private void des_crypt(ref UInt32[] SK, ref byte[] input, ref byte[] output)
        {
            UInt32 X = 0, Y = 0, T = 0;

            GET_UINT32(ref X, ref input, 0);
            GET_UINT32(ref Y, ref input, 4);

            DES_IP(ref X, ref Y, ref T);

            int nSK = -1;
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);

            DES_FP(ref Y, ref X, ref T);

            PUT_UINT32(ref Y, ref output, 0);
            PUT_UINT32(ref X, ref output, 4);
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
            des_main_ks(ref ctx.esk, ref key1, -1);
            des_main_ks(ref ctx.dsk, ref key2, 31);

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

        private void des3_crypt(ref UInt32[] SK, ref byte[] input, ref byte[] output)
        {
            UInt32 X = 0, Y = 0, T = 0;

            GET_UINT32(ref X, ref input, 0);
            GET_UINT32(ref Y, ref input, 4);

            DES_IP(ref X, ref Y, ref T);

            int nSK = -1;

            // encrypt
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);

            // decrypt
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK); DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK); DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK); DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK); DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK); DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK); DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK); DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);
            DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK); DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK);

            // encrypt
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);
            DES_ROUND(ref Y, ref X, ref T, ref SK, ref nSK); DES_ROUND(ref X, ref Y, ref T, ref SK, ref nSK);

            DES_FP(ref Y, ref X, ref T);

            PUT_UINT32(ref Y, ref output, 0);
            PUT_UINT32(ref X, ref output, 4);
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
            byte[] in_ = new byte[8];
            byte[] out_ = new byte[8];
            des3_context ctx;
            ctx.dsk = new uint[96];
            ctx.esk = new uint[96];
            int i = 0;
            int j = 0;
            byte[] temp;

            temp = output;

            // Set encryption keys
            byte[] key2 = new byte[8];
            Array.Copy(key, 8, key2, 0, 8);
            des3_set_2keys(ref ctx, ref key, ref key2);

            // clear buffers
            // (not necessary)

            // do for each 8 byte block of input
            for (i = 0; i <= (inputLength / (double)8) - 1; i++)
            {
                // copy 8 bytes from input buffer to in
                Array.Copy(input, i * 8, in_, 0, 8);

                // xor with ciphered block -1 
                for (j = 0; j <= 7; j++)
                {
                    in_[j] = (byte)(in_[j] ^ out_[j]);
                }

                // 3DES encryption
                des3_encrypt(ref ctx, ref in_, ref out_);

                // copy encrypted block to output
                Array.Copy(out_, 0, temp, i * 8, 8);
            }
            outputLength = inputLength;
        }

        public void decrypt_3des(byte[] key, byte[] input, int inputLength, ref byte[] output, ref int outputLength)
        {
            des3_context ctx;
            ctx.dsk = new uint[96];
            ctx.esk = new uint[96];

            byte[] in_ = new byte[8];
            byte[] out_ = new byte[8];
            byte[] in2 = new byte[8];

            byte[] temp;

            int i = 0;
            int j = 0;

            temp = output;

            // Set encryption keys
            byte[] key2 = new byte[8];
            Array.Copy(key, 8, key2, 0, 8);
            des3_set_2keys(ref ctx, ref key, ref key2);

            // clear buffers
            // (not necessary)

            // do for each 8 byte block of input
            for (i = 0; i <= (inputLength / (double)8) - 1; i++)
            {
                // copy 8 bytes from input buffer to in
                Array.Copy(input, i * 8, in_, 0, 8);

                // 3DES encryption
                des3_decrypt(ref ctx, ref in_, ref out_);

                // xor with ciphered block -1 
                for (j = 0; j <= 7; j++)
                    out_[j] = (byte)(in_[j] ^ out_[j]);

                Array.Copy(input, i * 8, in2, 0, 8);

                // copy encrypted block to output
                Array.Copy(out_, 0, temp, i * 8, 8);
            }
            outputLength = inputLength;
        }

        public void encrypt_des(byte[] key, byte[] input, int inputLength, ref byte[] output, ref int outputLength)
        {
            byte[] in_ = new byte[8];
            byte[] out_ = new byte[8];
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
            for (i = 0; i <= (inputLength / (double)8) - 1; i++)
            {
                // copy 8 bytes from input buffer to in
                Array.Copy(input, i * 8, in_, 0, 8);

                // xor with ciphered block -1 
                for (j = 0; j <= 7; j++)
                    in_[j] = (byte)(in_[j] ^ out_[j]);

                // DES encryption
                des_encrypt(ref ctx, ref in_, ref out_);

                // copy encrypted block to output
                Array.Copy(out_, 0, temp, i * 8, 8);
            }
            outputLength = inputLength;
        }

        public void decrypt_des(byte[] key, byte[] input, int inputLength, ref byte[] output, ref int outputLength)
        {
            des_context ctx;
            ctx.dsk = new uint[32];
            ctx.esk = new uint[32];

            byte[] in_ = new byte[8];
            byte[] out_ = new byte[8];
            byte[] in2 = new byte[8];

            byte[] temp;

            int i = 0;
            int j = 0;

            temp = output;

            // Set encryption keys
            des_set_key(ref ctx, ref key);

            // clear buffers
            // (not necessary)

            // do for each 8 byte block of input
            for (i = 0; i <= (inputLength / (double)8) - 1; i++)
            {
                // copy 8 bytes from input buffer to in
                Array.Copy(input, i * 8, in_, 0, 8);

                // DES encryption
                des_decrypt(ref ctx, ref in_, ref out_);

                // xor with ciphered block -1 
                for (j = 0; j <= 7; j++)
                    out_[j] = (byte)(in_[j] ^ out_[j]);

                Array.Copy(input, i * 8, in2, 0, 8);

                // copy encrypted block to output
                Array.Copy(out_, 0, temp, i * 8, 8);
            }
            outputLength = inputLength;
        }
    }
}
