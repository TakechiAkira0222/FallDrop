using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Playables;

namespace Takechi.ExternalData
{
    public class Save : MonoBehaviour
    {
        protected virtual void DataSave<DataClass>(DataClass saveData , string saveFilePath)
        {
            // �Z�[�u�f�[�^��JSON�`���̕�����ɕϊ�
            string jsonString = JsonUtility.ToJson(saveData);
            // �������byte�z��ɕϊ�
            byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
            // AES�Í���
            byte[] arrEncrypted = AesEncrypt(bytes);
            // �w�肵���p�X�Ƀt�@�C�����쐬
            FileStream file = new FileStream(saveFilePath, FileMode.Create, FileAccess.Write);

            //�t�@�C���ɕۑ�����
            try
            {
                // �t�@�C���ɕۑ�
                file.Write(arrEncrypted, 0, arrEncrypted.Length);
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

        /// AES�Í���
        public byte[] AesEncrypt(byte[] byteText)
        {
            // AES�}�l�[�W���[�̎擾
            AesManaged aes = GetAesManager();
            // �Í���
            byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

            return encryptText;
        }
    }
}
