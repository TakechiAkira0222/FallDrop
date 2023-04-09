using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Playables;

namespace Takechi.ExternalData
{
    public class Read : Save
    {
        protected virtual DataClass LoadData<DataClass>(DataClass saveData , string saveFilePath)
        {
            //�Z�[�u�t�@�C�������邩
            if (File.Exists(saveFilePath))
            {
                //�t�@�C�����[�h���I�[�v���ɂ���
                FileStream file = new FileStream(saveFilePath, FileMode.Open, FileAccess.Read);
                try
                {
                    // �t�@�C���ǂݍ���
                    byte[] arrRead = File.ReadAllBytes(saveFilePath);

                    // ������
                    byte[] arrDecrypt = AesDecrypt(arrRead);

                    // byte�z��𕶎���ɕϊ�
                    string decryptStr = Encoding.UTF8.GetString(arrDecrypt);

                    // JSON�`���̕�������Z�[�u�f�[�^�̃N���X�ɕϊ�
                    saveData = JsonUtility.FromJson<DataClass>(decryptStr);

                    return saveData;
                }
                catch
                {
                    Debug.LogError("The save data may have been tampered with.");
                    return saveData;
                }
                finally
                {
                    // �t�@�C�������
                    if (file != null)
                    {
                        file.Close();
                    }
                }
            }
            else
            {
                Debug.Log(" no save file ");
                return saveData;
            }
        }

        /// AesManaged�}�l�[�W���[���擾
        private AesManaged GetAesManager()
        {
            //�C�ӂ̔��p�p��16����
            string aesIv = "1234567890123456";
            string aesKey = "1234567890123456";

            AesManaged aes = new AesManaged();
            aes.KeySize = 128;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.IV = Encoding.UTF8.GetBytes(aesIv);
            aes.Key = Encoding.UTF8.GetBytes(aesKey);
            aes.Padding = PaddingMode.PKCS7;
            return aes;
        }

        /// AES������
        public byte[] AesDecrypt(byte[] byteText)
        {
            // AES�}�l�[�W���[�擾
            var aes = GetAesManager();
            // ������
            byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

            return decryptText;
        }
    }
}
